using FinShark.API.Dtos.Comment;
using FinShark.API.Models;

namespace FinShark.API.Repositories;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();

    Task<Comment> GetByIdAsync(int id);

    public Task CreateAsync(Comment comment);

    public Task<Comment> UpdateAsync(int id, UpdateCommentRequestDto dto);

    public Task DeleteByIdAsync(int id);
}