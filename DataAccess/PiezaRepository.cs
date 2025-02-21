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
                string query = @"SELECT 
                        p.PiezaID,
                        m.Nombre as Marca,
                        p.Modelo,
                        p.BarCode,
                        p.Descripcion,
                        c.Category as Categoria, 
                        p.Cantidad 
                        FROM Piezas AS p 
                    INNER JOIN Marcas AS m ON p.Marca = m.ID 
                    INNER JOIN Category As c ON p.Categoria = c.ID;";

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
        public async Task<DataTable> DynamicSearchItemAsync(string barcode, string modelo)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = @"SELECT p.PiezaID, m.Nombre as Marca, p.Modelo, p.BarCode, p.Descripcion, c.Category  as Categoria, p.Cantidad FROM Piezas AS p 
                    INNER JOIN Marcas AS m ON p.Marca = m.ID 
                    INNER JOIN Category As c ON p.Categoria = c.ID WHERE BarCode like @barcode or Modelo like @model ";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode + "%");
                    cmd.Parameters.AddWithValue("@model", modelo + "%");
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
                string query = @"UPDATE Piezas
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
        public async Task<DataTable> ComboBox_MarcaAsync()
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT ID, Nombre FROM Marcas ORDER BY Nombre ASC";

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
        public async Task<DataTable> ComboBox_CategoriaAsync()
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT ID, Category FROM Category ORDER BY Category ASC";

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
    }
}
