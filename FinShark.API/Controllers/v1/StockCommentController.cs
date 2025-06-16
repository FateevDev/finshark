using Asp.Versioning;
using FinShark.API.Dtos.Comment;
using FinShark.API.Exceptions;
using FinShark.API.Extensions;
using FinShark.API.Mappers;
using FinShark.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/stocks/{stockId:int}/comments")]
[Authorize]
public class StockCommentController(ICommentRepository repository, IStockRepository stockRepository) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetByStock([FromRoute] int stockId)
    {
        try
        {
            var stock = await stockRepository.GetByIdAsync(stockId);
            var commentsDtos = stock.Comments.Select(comment => comment.ToCommentDto());

            return Ok(commentsDtos);
        }
        catch (EntityNotFoundException<int> exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateForStock([FromRoute] int stockId,
        [FromBody] CreateCommentRequestDto dto)
    {
        try
        {
            var userId = User.GetUserId();
            await stockRepository.GetByIdAsync(stockId);
            var comment = dto.ToCommentFromCreateRequest(stockId, userId);
            await repository.CreateAsync(comment);

            return CreatedAtAction(nameof(GetByStock), new { stockId }, comment.ToCommentDto());
        }
        catch (EntityNotFoundException<int> exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPut("{commentId:int}")]
    public async Task<IActionResult> Update([FromRoute] int commentId, [FromBody] UpdateCommentRequestDto dto)
    {
        try
        {
            var userId = User.GetUserId();
            var comment = await repository.UpdateAsync(commentId, dto, userId);

            return Ok(comment.ToCommentDto());
        }
        catch (EntityNotFoundException<int> exception)
        {
            return NotFound(exception.Message);
        }
        catch (UpdateCommentException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{commentId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int commentId)
    {
        try
        {
            await repository.DeleteByIdAsync(commentId);

            return NoContent();
        }
        catch (EntityNotFoundException<int> exception)
        {
            return NotFound(exception.Message);
        }
    }
}