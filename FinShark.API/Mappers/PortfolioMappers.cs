using FinShark.API.Dtos.Portfolio;
using FinShark.API.Models;

namespace FinShark.API.Mappers;

public static class PortfolioMappers
{
    public static PortfolioDto ToDto(this Portfolio portfolio)
    {
        return new(
            portfolio.Id,
            portfolio.Stock!.ToStockDto(),
            portfolio.Quantity,
            portfolio.PurchasePrice,
            portfolio.CreatedOn
        );
    }

    public static Portfolio ToPortfolio(this CreatePortfolioRequestDto dto, string userId, int stockId)
    {
        return new Portfolio
        {
            UserId = userId,
            StockId = stockId,
            Quantity = dto.Quantity,
            PurchasePrice = dto.PurchasePrice,
            CreatedOn = DateTime.Now
        };
    }
}