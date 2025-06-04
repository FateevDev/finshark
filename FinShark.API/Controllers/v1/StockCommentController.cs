using Asp.Versioning;
using FinShark.API.Dtos.Comment;
using FinShark.API.Exceptions;
using FinShark.API.Mappers;
using FinShark.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/stocks/{stockId}/comments")]
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
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateForStock([FromRoute] int stockId,
        [FromBody] CreateCommentRequestDto dto)
    {
        try
        {
            await stockRepository.GetByIdAsync(stockId);
            var comment = dto.ToCommentFromCreateRequest(stockId);
            await repository.CreateAsync(comment);

            return CreatedAtAction(nameof(GetByStock), new { stockId }, comment.ToCommentDto());
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{commentId}")]
    public async Task<IActionResult> Update([FromRoute] int stockId,
        [FromRoute] int commentId, [FromBody] UpdateCommentRequestDto dto)
    {
        try
        {
            await stockRepository.GetByIdAsync(stockId);
            var comment = await repository.UpdateAsync(commentId, dto);

            return Ok(comment.ToCommentDto());
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{commentId}")]
    public async Task<IActionResult> Delete([FromRoute] int stockId, [FromRoute] int commentId)
    {
        try
        {
            await stockRepository.GetByIdAsync(stockId);
            await repository.DeleteByIdAsync(commentId);

            return NoContent();
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
    }
}