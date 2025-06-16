using FinShark.API.Data;
using FinShark.API.Exceptions;
using FinShark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Repositories;

public class PortfolioRepository(ApplicationDbContext dbContext) : IPortfolioRepository
{
    public Task<List<Portfolio>> GetByUserIdAsync(string userId)
    {
        return dbContext.Portfolios
            .Include(p => p.Stock)
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public async Task CreateAsync(Portfolio portfolio)
    {
        await dbContext.Portfolios.AddAsync(portfolio);
        await dbContext.SaveChangesAsync();
    }

    public Task DeleteByIdAsync(int portfolioId)
    {
        var portfolio = dbContext.Portfolios.Find(portfolioId);

        if (portfolio == null)
        {
            throw new EntityNotFoundException<int>(nameof(portfolio), portfolioId);
        }

        dbContext.Portfolios.Remove(portfolio);
        return dbContext.SaveChangesAsync();
    }
}