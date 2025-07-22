using FinShark.API.Dtos.Comment;
using FinShark.API.Models;

namespace FinShark.API.Mappers;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment comment)
    {
        return new CommentDto(
            comment.Id,
            comment.Title,
            comment.Content,
            comment.CreatedOn,
            comment.StockId,
            comment.User!.UserName!
        );
    }

    public static CommentDto ToCommentDto(this Comment comment, string userName)
    {
        return new CommentDto(
            comment.Id,
            comment.Title,
            comment.Content,
            comment.CreatedOn,
            comment.StockId,
            userName
        );
    }

    public static Comment ToCommentFromCreateRequest(this CreateCommentRequestDto dto, int stockId, string userId)
    {
        return new Comment
        {
            Title = dto.Title,
            Content = dto.Content,
            CreatedOn = DateTime.Now,
            StockId = stockId,
            UserId = userId
        };
    }

    public static void UpdateFromRequest(this Comment comment, UpdateCommentRequestDto dto)
    {
        comment.Title = dto.Title;
        comment.Content = dto.Content;
        comment.CreatedOn = dto.CreatedOn;
    }
}