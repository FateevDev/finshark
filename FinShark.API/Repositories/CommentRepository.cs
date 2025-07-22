using FinShark.API.Data;
using FinShark.API.Dtos.Comment;
using FinShark.API.Exceptions;
using FinShark.API.Mappers;
using FinShark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Repositories;

public class CommentRepository(ApplicationDbContext dbContext) : ICommentRepository
{
    public async Task<List<Comment>> GetAllAsync()
    {
        return await dbContext.Comments.Include(comment => comment.User).ToListAsync();
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        var comment = await dbContext.Comments
            .Include(comment => comment.User)
            .FirstOrDefaultAsync(comment => comment.Id == id);

        if (comment == null)
        {
            throw new EntityNotFoundException<int>(nameof(Comment), id);
        }

        return comment;
    }

    public async Task CreateAsync(Comment comment)
    {
        await dbContext.Comments.AddAsync(comment);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Comment> UpdateAsync(int id, UpdateCommentRequestDto dto, string userId)
    {
        var comment = await GetByIdAsync(id);

        if (comment.UserId != userId)
        {
            throw UpdateCommentException.CanNotUpdateOtherUserComment();
        }

        comment.UpdateFromRequest(dto);

        await dbContext.SaveChangesAsync();

        return comment;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var comment = await GetByIdAsync(id);

        dbContext.Comments.Remove(comment);
        await dbContext.SaveChangesAsync();
    }
}