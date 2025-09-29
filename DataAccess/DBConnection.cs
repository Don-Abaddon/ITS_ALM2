using System.Data.Common;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    /// <summary>
    /// Class to manage the connection to the database
    /// </summary>
    public abstract class DBConnection
    {
        public static DbConnection CreateConnection(DBSettingRead.DbProfileSettings s)
        => s.Provider switch
        {
            "sqlite" => new SqliteConnection(s.ConnectionString),
            "mysql"  => new MySqlConnection(s.ConnectionString),
            _ => throw new NotSupportedException($"Proveedor no soportado: {s.Provider}")
        };

        public static string ProviderFolder(DBSettingRead.DbProfileSettings s)
        => Path.Combine(s.SqlFolder, s.Provider);
        /// <summary>
        /// Asegura que la base de datos exista (crea SQLite si falta, MySQL solo valida conexión),
        /// aplica migraciones si existen, y valida tablas requeridas.
        /// Devuelve true si todo OK; si falla, devuelve false y mensaje de error.
        /// </summary>
        public static bool EnsureDatabaseAndSchema(
            DBSettingRead.DbProfileSettings s,
            IEnumerable<string> requiredTables,
            out List<string> missingTables,
            out string errorMessage)
        {
            missingTables = new List<string>();
            errorMessage = string.Empty;

            try
            {
                if (s.Provider.Equals("sqlite", StringComparison.OrdinalIgnoreCase))
                {
                    EnsureSqliteFileExists(s);
                    using var conn = new SqliteConnection(s.ConnectionString);
                    conn.Open();
                    ApplyMigrationsIfAny(conn, Path.Combine(ProviderFolder(s), "migrations"));
                    missingTables = FindMissingTables(conn, requiredTables, isSqlite: true);
                    return missingTables.Count == 0;
                }
                else if (s.Provider.Equals("mysql", StringComparison.OrdinalIgnoreCase))
                {
                    // Solo validar conexión (si la DB no existe fallará aquí)
                    using var conn = new MySqlConnection(s.ConnectionString);
                    try { conn.Open(); }
                    catch (Exception ex)
                    {
                        errorMessage = $"No hay conexión a MySQL: {ex.Message}";
                        return false;
                    }

                    // (Opcional) aplicar migraciones si las tienes para MySQL
                    ApplyMigrationsIfAny(conn, Path.Combine(ProviderFolder(s), "migrations"));

                    missingTables = FindMissingTables(conn, requiredTables, isSqlite: false);
                    return missingTables.Count == 0;
                }
                else
                {
                    errorMessage = $"Proveedor no soportado: {s.Provider}";
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        // ====================== Helpers ======================

        // Asegura archivo SQLite y carpeta, y si no existe ejecuta la migración inicial
        private static void EnsureSqliteFileExists(DBSettingRead.DbProfileSettings s)
        {
            var csb = new SqliteConnectionStringBuilder(s.ConnectionString);
            var dbPath = ToAbsolutePath(csb.DataSource);
            var dir = Path.GetDirectoryName(dbPath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(dbPath))
            {
                // Ejecuta SOLO la primera migración o todas si prefieres
                using var conn = new SqliteConnection($"Data Source={dbPath}");
                conn.Open();
                var migDir = Path.Combine(ProviderFolder(s), "migrations");
                ApplyMigrationsIfAny(conn, migDir); // creará tablas desde tus .sql
            }
        }

        // Aplica TODAS las .sql del directorio en orden por nombre (idempotente si usas IF NOT EXISTS)
        private static void ApplyMigrationsIfAny(DbConnection conn, string migrationsDir)
        {
            if (!Directory.Exists(migrationsDir))
                return;

            var files = Directory.GetFiles(migrationsDir, "*.sql")
                                 .OrderBy(f => f, StringComparer.OrdinalIgnoreCase);

            foreach (var file in files)
            {
                var script = File.ReadAllText(file);
                ExecuteScript(conn, script);
            }
        }

        // Ejecuta múltiples sentencias separadas por ';'
        private static void ExecuteScript(DbConnection conn, string script)
        {
            // Split naive por ';' (sirve si tus scripts no tienen procedimientos con ';' internos)
            foreach (var chunk in script.Split(';'))
            {
                var sql = chunk.Trim();
                if (string.IsNullOrWhiteSpace(sql)) continue;

                using var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        // Devuelve la lista de tablas faltantes comparando contra el esquema
        private static List<string> FindMissingTables(DbConnection conn, IEnumerable<string> requiredTables, bool isSqlite)
        {
            var req = requiredTables.Select(t => t.Trim()).Where(t => t.Length > 0).ToList();
            if (req.Count == 0) return new List<string>();

            string inList = string.Join(",", req.Select(t => isSqlite ? $"'{t}'" : $"'{t}'"));

            string sql = isSqlite
                ? $"SELECT name FROM sqlite_master WHERE type='table' AND name IN ({inList});"
                : $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME IN ({inList});";

            var found = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var name = r.GetString(0);
                    found.Add(name);
                }
            }

            return req.Where(t => !found.Contains(t)).ToList();
        }

        private static string ToAbsolutePath(string path)
        {
            if (Path.IsPathRooted(path)) return path;
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, path));
        }
    }
}
