using FinShark.API.Dtos.Stock;
using FinShark.API.Models;

namespace FinShark.API.Repositories;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync(StockQueryObject query);

    Task<Stock> GetByIdAsync(int id);

    Task<Stock> GetBySymbolAsync(string symbol);

    public Task CreateAsync(Stock stock);

    public Task<Stock> UpdateAsync(int id, UpdateStockRequestDto dto);

    public Task DeleteByIdAsync(int id);
}