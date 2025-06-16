using FinShark.API.Dtos.Stock;

namespace FinShark.API.Dtos.Portfolio;

public record PortfolioDto(
    int Id,
    StockDto Stock,
    int Quantity,
    decimal PurchasePrice,
    DateTime CreatedOn
);