using FinShark.API.Data;
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
}