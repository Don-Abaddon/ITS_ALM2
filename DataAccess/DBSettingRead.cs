using System.Text.Json;

namespace DataAccess
{
    public class DBSettingRead
    {
        public class DbProfileSettings
        {
            public string Provider { get; set; } = "";
            public string ConnectionString { get; set; } = "";
            public string SqlFolder { get; set; } = "";
        }

        public class DbSettings
        {
            public string SelectedProfile { get; set; } = "sqlite";
            public Dictionary<string, DbProfileSettings> Profiles { get; set; } = new();
        }

        public class AppSettings
        {
            public DbSettings Database { get; set; } = new();
        }

        // === Loader: lee appsettings.json y devuelve el perfil ACTIVO ===
        public static DbProfileSettings LoadActiveProfile(string path = "appsettings.json")
        {
            // Busca primero junto al .exe (bin/…)
            var baseDir = AppContext.BaseDirectory;
            var fullPath = Path.Combine(baseDir, path);
            if (!File.Exists(fullPath)) fullPath = path;

            var json = File.ReadAllText(fullPath);

            var settings = JsonSerializer.Deserialize<AppSettings>(json)
                           ?? throw new InvalidOperationException("No se pudo deserializar appsettings.json");

            var key = settings.Database.SelectedProfile;
            if (string.IsNullOrWhiteSpace(key) || !settings.Database.Profiles.ContainsKey(key))
                throw new InvalidOperationException($"SelectedProfile '{key}' no existe en Profiles.");

            return settings.Database.Profiles[key];
        }
    }
}