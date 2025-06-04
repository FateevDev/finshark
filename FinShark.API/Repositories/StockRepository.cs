using FinShark.API.Data;
using FinShark.API.Dtos.Stock;
using FinShark.API.Exceptions;
using FinShark.API.Mappers;
using FinShark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Repositories;

public class StockRepository(ApplicationDbContext dbContext) : IStockRepository
{
    public async Task<List<Stock>> GetAllAsync()
    {
        return await dbContext.Stocks.Include(stock => stock.Comments).ToListAsync();
    }

    public async Task<Stock> GetByIdAsync(int id)
    {
        var stock = await dbContext.Stocks
            .Include(stock => stock.Comments)
            .FirstOrDefaultAsync(stock => stock.Id == id);

        if (stock == null)
        {
            throw new EntityNotFoundException(nameof(Stock), id);
        }

        return stock;
    }

    public async Task CreateAsync(Stock stock)
    {
        await dbContext.Stocks.AddAsync(stock);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Stock> UpdateAsync(int id, UpdateStockRequestDto dto)
    {
        var stock = await GetByIdAsync(id);

        stock.UpdateFromRequest(dto);

        await dbContext.SaveChangesAsync();

        return stock;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var stock = await GetByIdAsync(id);

        dbContext.Stocks.Remove(stock);
        await dbContext.SaveChangesAsync();
    }
}