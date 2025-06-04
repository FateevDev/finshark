namespace FinShark.API.Dtos.Comment;

public record UpdateCommentRequestDto(
    string Title,
    string Content,
    DateTime CreatedOn
);