using DataAccess;
using System.Data;
using static DataAccess.DBConnection;
namespace Domain
{
    /// <summary>
    /// Clase para manejar el inventario de piezas
    /// </summary>
    public class Inventory : IDisposable
    {
        private PiezaRepository _piezaRepository;
        private readonly DatabaseWatcher _dbWatcher;
        public event EventHandler? InventoryUpdated;

        public Inventory()
        {
            _piezaRepository = new PiezaRepository();
            _dbWatcher = new DatabaseWatcher(DBConnection.GetDatabasePath()); // Ruta de la BD

            _dbWatcher.DatabaseChanged += async (s, e) => await NotifyUpdate();
        }
        /// <summary>
        /// Dispara el evento InventoryUpdated después de un retraso de 200 ms
        /// </summary>
        /// <returns></returns>
        private async Task NotifyUpdate()
        {
            await Task.Delay(200); // Pequeño retraso para evitar problemas de concurrencia
            InventoryUpdated?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Libera los recursos del DatabaseWatcher
        /// </summary>
        public void Dispose()
        {
            _dbWatcher?.Dispose();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Carga los items de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> LoadItems()
        {
            return await _piezaRepository.GetAllPiezasAsync();
        }
        /// <summary>
        /// Carga las marcas de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> Combobox_Marca()
        {
            return await _piezaRepository.ComboBox_MarcaAsync();
        }
        /// <summary>
        /// Carga las categorías de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> Combobox_Categoria()
        {
            return await _piezaRepository.ComboBox_CategoriaAsync();
        }
        /// <summary>
        /// Realiza una búsqueda dinámica de items en la base de datos
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public async Task<DataTable> DynamicSearchItem(string barcode, string categoryID)
        {
            return await _piezaRepository.DynamicSearchItemAsync(barcode, categoryID);
        }
        /// <summary>
        /// Realiza una búsqueda exacta de un item en la base de datos
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<DataTable> ExactSearchItem( string barcode)
        {
            return await _piezaRepository.ExactSearchItemAsync(barcode);
        }
        /// <summary>
        /// Realiza una búsqueda de items por marca y categoría
        /// </summary>
        /// <param name="marcaID"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public async Task<DataTable> SearchItem(string marcaID, string categoryID)
        {
            return await _piezaRepository.SearchItemAsync(marcaID, categoryID);
        }
        /// <summary>
        /// Guarda un item en la base de datos
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="barcode"></param>
        /// <param name="descripcion"></param>
        /// <param name="categoria"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public async Task<DataTable> SaveItemsAsync(string marca, string modelo, string barcode, string descripcion, string categoria, int cantidad)
        {
            return await _piezaRepository.SaveItemsAsync(marca,  modelo,  barcode,  descripcion,  categoria,  cantidad);
        }
        /// <summary>
        /// Actualiza un item en la base de datos
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="barcode"></param>
        /// <param name="descripcion"></param>
        /// <param name="categoria"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public async Task<DataTable> UpdateItems(string ID, string marca, string modelo, string barcode, string descripcion, string categoria, int cantidad)
        {
            return await _piezaRepository.UpdateItemsAsync(ID, marca, modelo, barcode, descripcion, categoria, cantidad);
        }
        /// <summary>
        /// Elimina un item de la base de datos
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<DataTable> DeleteItems(string ID)
        {
            return await _piezaRepository.DeleteItemsAsync(ID);
        }
        /// <summary>
        /// Agrega items a la base de datos
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public async Task<DataTable> AddItems( string ID, int cantidad)
        {
            return await _piezaRepository.AddItemsAsync(ID,cantidad);
        }
        /// <summary>
        /// Verifica si la base de datos existe y la crea si no
        /// </summary>
        /// <exception cref="DataAccessException"></exception>
        public void EnsureDatabaseCreated()
        {
            try
            {
                // Llamada a DBConnection, que internamente puede lanzar DataAccessException
                var dbPath = DBConnection.DatabasePath;
                // Si la DB no existe, se creará automáticamente en la propiedad ConnectionString
                _ = DBConnection.ConnectionString;
            }
            catch (DataAccessException ex)
            {

                throw new DataAccessException("Error al procesar datos de la base de datos", ex);
            }
        }
    }
}
