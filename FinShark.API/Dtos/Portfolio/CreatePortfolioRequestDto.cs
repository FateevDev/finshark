namespace FinShark.API.Dtos.Portfolio;

public record CreatePortfolioRequestDto(
    string StockSymbol,
    int Quantity,
    decimal PurchasePrice
);