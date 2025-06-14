using FinShark.API.Dtos.Stock;

namespace FinShark.API.Dtos.Portfolio;

public record PortfolioDto(
    StockDto Stock,
    int Quantity,
    decimal PurchasePrice,
    DateTime CreatedOn
);