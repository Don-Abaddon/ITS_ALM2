using System.Data;
using Microsoft.Data.Sqlite;

namespace DataAccess
{
    public class PiezaRepository
    {
        public async Task<DataTable> GetAllPiezasAsync()
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM Piezas";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> DynamicSearchItemAsync(string barcode)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM Piezas WHERE BarCode like @barcode";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode + "%");
                    Console.Write(barcode);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> ExactSearchItemAsync(string barcode)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM Piezas WHERE BarCode = @barcode";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    Console.Write(barcode);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> SaveItemsAsync(string marca, string modelo, string barcode, string descripcion, string categoria, int cantidad)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = @"INSERT INTO Piezas 
                                     (Marca, 
                                     Modelo, 
                                     BarCode, 
                                     Descripcion, 
                                     Categoria, 
                                     Cantidad) 
                                 Values
                                    (@Marca, 
                                    @Modelo, 
                                    @barcode, 
                                    @Descripcion, 
                                    @Categoria, 
                                    @Cantidad)";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    cmd.Parameters.AddWithValue("@Marca", marca);
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Categoria", categoria);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }

            }
        }
        public async Task<DataTable> UpdateItemsAsync(string ID, string marca, string modelo, string barcode, string descripcion, string categoria, int cantidad)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = @"
                                UPDATE Piezas
                                SET 
                                    Marca = @Marca, 
                                    Modelo = @Modelo, 
                                    BarCode = @barcode, 
                                    Descripcion = @Descripcion, 
                                    Categoria = @Categoria, 
                                    Cantidad = @Cantidad
                                WHERE PiezaID = @id";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    cmd.Parameters.AddWithValue("@Marca", marca);
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Categoria", categoria);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> DeleteItemsAsync(string ID)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = @"DELETE FROM Piezas
                                WHERE PiezaID = @id";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> AddItemsAsync(string ID, int cantidad)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = @"UPDATE  Piezas SET Cantidad = @cantidad WHERE PiezaID = @id ";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
    }
}
