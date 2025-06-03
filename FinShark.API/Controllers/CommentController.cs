using FinShark.API.Dtos.Comment;
using FinShark.API.Mappers;
using FinShark.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers;

[ApiController]
[Route("api/comment")]
public class CommentController(ICommentRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await repository.GetAllAsync();
        var commentsDtos = comments.Select(comment => comment.ToCommentDto());

        return Ok(commentsDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await repository.GetByIdAsync(id);

        return Ok(comment.ToCommentDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentRequestDto dto)
    {
        var comment = dto.ToCommentFromCreateRequest();
        await repository.CreateAsync(comment);

        return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto dto)
    {
        var comment = await repository.UpdateAsync(id, dto);

        return Ok(comment.ToCommentDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await repository.DeleteByIdAsync(id);

        return NoContent();
    }
}