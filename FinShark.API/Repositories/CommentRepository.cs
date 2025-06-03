using FinShark.API.Data;
using FinShark.API.Dtos.Comment;
using FinShark.API.Mappers;
using FinShark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Repositories;

public class CommentRepository(ApplicationDbContext dbContext) : ICommentRepository
{
    public async Task<List<Comment>> GetAllAsync()
    {
        return await dbContext.Comments.ToListAsync();
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        var comment = await dbContext.Comments.FindAsync(id);

        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        return comment;
    }

    public async Task CreateAsync(Comment comment)
    {
        await dbContext.Comments.AddAsync(comment);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Comment> UpdateAsync(int id, UpdateCommentRequestDto dto)
    {
        var comment = await GetByIdAsync(id);
        
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