using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
