using FinShark.API.Dtos.Portfolio;
using FinShark.API.Models;

namespace FinShark.API.Mappers;

public static class PortfolioMappers
{
    public static PortfolioDto ToDto(this Portfolio portfolio)
    {
        return new(portfolio.Stock.ToStockDto(), portfolio.Quantity, portfolio.PurchasePrice, portfolio.CreatedOn);
    }
}