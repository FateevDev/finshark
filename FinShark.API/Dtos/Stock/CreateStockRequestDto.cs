namespace FinShark.API.Dtos.Stock;

public record CreateStockRequestDto(
    string Symbol,
    string CompanyName,
    decimal Purchase,
    decimal LastDiv,
    string Industry,
    long MarketCap
);
