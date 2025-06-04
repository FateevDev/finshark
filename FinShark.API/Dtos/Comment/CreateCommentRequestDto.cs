namespace FinShark.API.Dtos.Comment;

public record CreateCommentRequestDto(
    string Title,
    string Content,
    DateTime CreatedOn
);