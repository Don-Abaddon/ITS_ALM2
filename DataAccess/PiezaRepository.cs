using System.Data;
using Microsoft.Data.Sqlite;

namespace DataAccess
{
    /// <summary>
    /// Class to manage the connection to the database
    /// </summary>
    public class PiezaRepository
    {
        /// <summary>
        /// Get all the items from the database
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Get the items from the database by barcode and category
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public async Task<DataTable> DynamicSearchItemAsync(string barcode, string categoryID)
        { 
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                if (barcode == "Barcode")
                {
                    barcode = "";
                }
                await conn.OpenAsync();
                string query = @"SELECT p.PiezaID, m.Nombre as Marca, 
                    p.Modelo, p.BarCode, p.Descripcion, c.Category  as Categoria, p.Cantidad 
                    FROM Piezas AS p 
                    JOIN Marcas AS m ON p.Marca = m.ID 
                    JOIN Category As c ON p.Categoria = c.ID 
                    WHERE (@barcode IS NULL OR p.BarCode like @barcode) 
                    AND (@category IS NULL OR p.Categoria = @category)";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", "%"+ barcode + "%");
                    if (string.IsNullOrEmpty(categoryID))
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@category", categoryID);
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
        /// <summary>
        /// Get the items from the database by barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<DataTable> ExactSearchItemAsync(string barcode)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = @"SELECT p.PiezaID, m.Nombre as Marca, p.Modelo, p.BarCode, p.Descripcion, c.Category  as Categoria, p.Cantidad FROM Piezas AS p 
                    INNER JOIN Marcas AS m ON p.Marca = m.ID 
                    INNER JOIN Category As c ON p.Categoria = c.ID WHERE BarCode = @barcode"; ;
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
        /// <summary>
        /// Get the items from the database by marca and category
        /// </summary>
        /// <param name="marcaID"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public async Task<DataTable> SearchItemAsync(string marcaID, string categoryID)
        {
            using (var conn = new SqliteConnection(DBConnection.ConnectionString))
            {
                await conn.OpenAsync();
                string query = @"SELECT p.PiezaID, m.Nombre as Marca, p.Modelo, 
                    p.BarCode, p.Descripcion, c.Category  as Categoria, p.Cantidad 
                    FROM Piezas AS p 
                    INNER JOIN Marcas AS m ON p.Marca = m.ID 
                    INNER JOIN Category As c ON p.Categoria = c.ID 
                    WHERE (@marca IS NULL OR p.Marca = @marca)
                    AND (@categoria IS NULL OR p.Categoria = @categoria)";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@marca", string.IsNullOrEmpty(marcaID) ? DBNull.Value : (object)marcaID);
                    cmd.Parameters.AddWithValue("@categoria", string.IsNullOrEmpty(categoryID) ? DBNull.Value : (object)categoryID);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
        /// <summary>
        /// Save the items to the database
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="barcode"></param>
        /// <param name="descripcion"></param>
        /// <param name="categoria"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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
                    await cmd.ExecuteNonQueryAsync();
                }
                // Obtener el ID del registro insertado
                long lastId;
                using (var idCmd = new SqliteCommand("SELECT last_insert_rowid()", conn))
                {
                    object? result = await idCmd.ExecuteScalarAsync();
                    if (result is null)
                    {
                        throw new InvalidOperationException("No se obtuvo el valor de last_insert_rowid.");
                    }
                    lastId = Convert.ToInt64(result);
                }

                // Ejecutar SELECT para obtener el registro insertado
                string selectQuery = @"SELECT * FROM Piezas WHERE PiezaID = @id";
                using (var selectCmd = new SqliteCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@id", lastId);
                    using (var reader = await selectCmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }
            }
        }
        /// <summary>
        /// Update the items to the database
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="barcode"></param>
        /// <param name="descripcion"></param>
        /// <param name="categoria"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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
                    await cmd.ExecuteNonQueryAsync();
                }
                // Obtener el ID del registro insertado
                long lastId;
                using (var idCmd = new SqliteCommand("SELECT last_insert_rowid()", conn))
                {
                    object? result = await idCmd.ExecuteScalarAsync();
                    if (result is null)
                    {
                        throw new InvalidOperationException("No se obtuvo el valor de last_insert_rowid.");
                    }
                    lastId = Convert.ToInt64(result);
                }

                // Ejecutar SELECT para obtener el registro insertado
                string selectQuery = @"SELECT * FROM Piezas WHERE PiezaID = @id";
                using (var selectCmd = new SqliteCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@id", lastId);
                    using (var reader = await selectCmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }
            }            
        }
        /// <summary>
        /// Delete the items from the database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add the items to the database
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get the items from the database by ID to fill the combobox
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Get the items from the database by ID to fill the combobox
        /// </summary>
        /// <returns></returns>
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
