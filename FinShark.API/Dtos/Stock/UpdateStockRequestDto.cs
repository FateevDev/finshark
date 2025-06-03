namespace FinShark.API.Dtos.Stock;

public record UpdateStockRequestDto(
    string Symbol,
    string CompanyName,
    decimal Purchase,
    decimal LastDiv,
    string Industry,
    long MarketCap
);