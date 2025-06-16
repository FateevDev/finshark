using FinShark.API.Models;

namespace FinShark.API.Repositories;

public interface IPortfolioRepository
{
    Task<List<Portfolio>> GetByUserIdAsync(string userId);
    Task CreateAsync(Portfolio portfolio);
    Task DeleteByIdAsync(int portfolioId, string userId);
}