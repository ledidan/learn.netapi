using DTOs.Stock;
using Helpers;
using Models;

namespace Interfaces.IStock
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDTO stockDTO);

        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExists(int id);
    }
}