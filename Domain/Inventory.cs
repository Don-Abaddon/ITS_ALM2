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
    }
}
