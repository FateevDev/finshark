using FinShark.API.Dtos.Comment;

namespace FinShark.API.Dtos.Stock;

public record StockDto(
    int Id,
    string Symbol,
    string CompanyName,
    decimal Purchase,
    decimal LastDiv,
    string Industry,
    long MarketCap,
    List<CommentDto> Comments
);