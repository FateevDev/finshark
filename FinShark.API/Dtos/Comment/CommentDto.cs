namespace FinShark.API.Dtos.Comment;

public record CommentDto(
    int Id,
    string Title,
    string Content,
    DateTime CreatedOn,
    int? StockId,
    string UserName
);