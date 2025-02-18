using DataAccess;
using System.Data;
namespace Domain
{
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
        private async Task NotifyUpdate()
        {
            await Task.Delay(200); // Pequeño retraso para evitar problemas de concurrencia
            InventoryUpdated?.Invoke(this, EventArgs.Empty);
        }
        public void Dispose()
        {
            _dbWatcher?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<DataTable> LoadItems()
        {
            return await _piezaRepository.GetAllPiezasAsync();
        }
        public async Task<DataTable> Combobox_Marca()
        {
            return await _piezaRepository.ComboBox_MarcaAsync();
        }
        public async Task<DataTable> Combobox_Categoria()
        {
            return await _piezaRepository.ComboBox_CategoriaAsync();
        }
        public async Task<DataTable> DynamicSearchItem(string barcode, string modelo)
        {
            return await _piezaRepository.DynamicSearchItemAsync(barcode, modelo);
        }
        public async Task<DataTable> ExactSearchItem( string barcode)
        {
            return await _piezaRepository.ExactSearchItemAsync(barcode);
        }
        public async Task<DataTable> SaveItemsAsync(string marca, string modelo, string barcode, string descripcion, string categoria, int cantidad)
        {
            return await _piezaRepository.SaveItemsAsync(marca,  modelo,  barcode,  descripcion,  categoria,  cantidad);
        }
        public async Task<DataTable> UpdateItems(string ID, string marca, string modelo, string barcode, string descripcion, string categoria, int cantidad)
        {
            return await _piezaRepository.UpdateItemsAsync(ID, marca, modelo, barcode, descripcion, categoria, cantidad);
        }
        public async Task<DataTable> DeleteItems(string ID)
        {
            return await _piezaRepository.DeleteItemsAsync(ID);
        }
        public async Task<DataTable> AddItems( string ID, int cantidad)
        {
            return await _piezaRepository.AddItemsAsync(ID,cantidad);
        }
    }
}
