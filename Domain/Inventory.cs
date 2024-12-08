using DataAccess;
using System.Data;
namespace Domain
{
    public class Inventory
    {
        private PiezaRepository _piezaRepository;
        public Inventory()
        {
            _piezaRepository = new PiezaRepository();
        }

        public async Task<DataTable> LoadItems()
        {
            return await _piezaRepository.GetAllPiezasAsync();
        }
        public async Task<DataTable> DynamicSearchItem(string barcode)
        {
            return await _piezaRepository.DynamicSearchItemAsync(barcode);
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
