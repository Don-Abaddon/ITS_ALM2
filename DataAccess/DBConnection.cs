using Microsoft.Data.Sqlite;

namespace DataAccess
{
    /// <summary>
    /// Class to manage the connection to the database
    /// </summary>
    public abstract class DBConnection
    {
        /// <summary>
        /// Path to the database file
        /// </summary>
        private static readonly string basePath = @"\\prt-itstech\itstech\Yamil\";
        private static readonly string folderPath = System.IO.Path.Combine(basePath, "ITS_ALM");
        private static readonly string dbPath = System.IO.Path.Combine(folderPath, "its_alm2.db");
        public static string DatabasePath => dbPath;
        /// <summary>
        /// Connection string to the database
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (!Directory.Exists(folderPath))
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
        /// <summary>
        /// Get the path to the database
        /// </summary>
        /// <returns></returns>
        public static string GetDatabasePath()
        {
            return dbPath;
        }
        /// <summary>
        /// Create the database
        /// </summary>
        /// <param name="dbPath"></param>
        /// <exception cref="DataAccessException"></exception>
        private static void CreateDatabase(string dbPath)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();

                    string createTableQuery = @"CREATE TABLE Marcas(
	                    ID INTEGER,
	                    Nombre TEXT,
	                    PRIMARY KEY(ID AUTOINCREMENT)
                    );

                    CREATE TABLE Category(
	                    ID INTEGER,
	                    Category TEXT,
	                    PRIMARY KEY (ID AUTOINCREMENT)
                    );
	
                    CREATE TABLE Piezas (
	                    PiezaID	INTEGER,
	                    Marca	INTEGER NOT NULL,
	                    Modelo	INT NOT NULL,
	                    BarCode	TEXT(20) UNIQUE,
	                    Descripcion	TEXT,
	                    Categoria	INT NOT NULL,
	                    Cantidad	INT NOT NULL,
	                    PRIMARY KEY(PiezaID AUTOINCREMENT),
	                    FOREIGN KEY (Marca) REFERENCES Marcas(ID),
	                    FOREIGN KEY (Categoria) REFERENCES Category(ID)
                    );";

                    using (var command = new SqliteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error al crear la base de datos", ex);
            }
        }
        /// <summary>
        /// Exception for data access
        /// </summary>
        public class DataAccessException : Exception
        {
            public DataAccessException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }
        /// <summary>
        /// Get a connection to the database
        /// </summary>
        /// <returns></returns>
        protected SqliteConnection GetConenction()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}
