using Microsoft.Data.Sqlite;
namespace DataAccess
{
    public abstract class DBConnection
    {
        public static string ConnectionString
        {
            get
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string dbPath = System.IO.Path.Combine(basePath, "db", "its_alm.db");
                Console.WriteLine(dbPath);
                return $"Data Source={dbPath}";
            }
        }
        protected SqliteConnection GetConenction()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}
