using FinShark.API.Data;
using FinShark.API.Dtos.Stock;
using FinShark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Repositories;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();

    Task<Stock> GetByIdAsync(int id);

    public Task CreateAsync(Stock stock);

    public Task<Stock> UpdateAsync(int id, UpdateStockRequestDto dto);

    public Task DeleteByIdAsync(int id);
}