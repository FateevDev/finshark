namespace FinShark.API.Dtos.Stock;

public record StockQueryObject(
    string? Symbol,
    string? CompanyName,
    long? MarketCapMin,
    long? MarketCapMax,
    string? Sort
);