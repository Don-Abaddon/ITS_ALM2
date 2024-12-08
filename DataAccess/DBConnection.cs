using Microsoft.Data.Sqlite;
namespace DataAccess
{
    public abstract class DBConnection
    {
        public static string ConnectionString
        {
            get
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string folderPath = System.IO.Path.Combine(basePath, "ITS_ALM");
                string dbPath = System.IO.Path.Combine(folderPath, "its_alm.db");


                if (!Directory.Exists(dbPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                if (!File.Exists(dbPath))
                {
                    CreateDatabase(dbPath);
                }

                return $"Data Source={dbPath}";
            }
        }
        private static void CreateDatabase(string dbPath)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Piezas (
                    PiezaID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Marca TEXT NOT NULL,
                    Modelo TEXT NOT NULL,
                    BarCode TEXT NOT NULL,
                    Descripcion TEXT,
                    Categoria TEXT,
                    Cantidad INTEGER NOT NULL
                );";

                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        protected SqliteConnection GetConenction()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}
