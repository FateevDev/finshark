using System.Linq.Expressions;
using FinShark.API.Data;
using FinShark.API.Dtos.Stock;
using FinShark.API.Exceptions;
using FinShark.API.Mappers;
using FinShark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Repositories;

public class StockRepository(ApplicationDbContext dbContext) : IStockRepository
{
    private static readonly Dictionary<string, Expression<Func<Stock, object>>> SortExpressions =
        new(StringComparer.OrdinalIgnoreCase)
        {
            { "id", stock => stock.Id },
            { "symbol", stock => stock.Symbol },
            { "companyName", stock => stock.CompanyName },
            { "purchase", stock => stock.Purchase },
            { "lastDiv", stock => stock.LastDiv },
            { "industry", stock => stock.Industry },
            { "marketCap", stock => stock.MarketCap }
        };

    public async Task<List<Stock>> GetAllAsync(StockQueryObject query)
    {
        return await dbContext.Stocks
            .Include(stock => stock.Comments)
            .AsQueryable()
            .When(!string.IsNullOrWhiteSpace(query.Symbol),
                q => q.Where(stock => stock.Symbol.Contains(query.Symbol!)))
            .When(!string.IsNullOrWhiteSpace(query.CompanyName),
                q => q.Where(stock => stock.CompanyName.Contains(query.CompanyName!)))
            .When(query.MarketCapMin.HasValue, q => q.Where(stock => stock.MarketCap >= query.MarketCapMin))
            .When(query.MarketCapMax.HasValue, q => q.Where(stock => stock.MarketCap <= query.MarketCapMax))
            .When(!string.IsNullOrWhiteSpace(query.Sort), q =>
            {
                bool isDescending = query.Sort!.StartsWith("-");
                string sortField = query.Sort.TrimStart('-');

                if (!SortExpressions.TryGetValue(sortField, out var expression))
                {
                    return q;
                }

                return isDescending ? q.OrderByDescending(expression) : q.OrderBy(expression);
            })
            .Skip(query.Offset)
            .Take(query.Limit)
            .ToListAsync();
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