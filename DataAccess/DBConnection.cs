using Microsoft.Data.Sqlite;
namespace DataAccess
{
    public abstract class DBConnection
    {
        public static string ConnectionString
        {
            get
            {
                string basePath = @"\\prt-itstech\itstech\Yamil\";
                string folderPath = System.IO.Path.Combine(basePath, "ITS_ALM");
                string dbPath = System.IO.Path.Combine(folderPath, "its_alm2.db");


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
	                    Marca	TEXT(100) NOT NULL,
	                    Modelo	TEXT(100) NOT NULL,
	                    BarCode	TEXT(20) UNIQUE,
	                    Descripcion	TEXT,
	                    Categoria	TEXT(50) NOT NULL,
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

        protected SqliteConnection GetConenction()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}
