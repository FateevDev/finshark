using FinShark.API.Dtos.Stock;
using FinShark.API.Exceptions;
using FinShark.API.Mappers;
using FinShark.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers;

[ApiController]
[Route("api/stocks")]
public class StockController(IStockRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stocks = await repository.GetAllAsync();
        var stockDtos = stocks.Select(stock => stock.ToStockDto());

        return Ok(stockDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var stock = await repository.GetByIdAsync(id);

            return Ok(stock.ToStockDto());
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        var stock = stockDto.ToStockFromCreateRequest();
        await repository.CreateAsync(stock);

        return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
    {
        var stock = await repository.UpdateAsync(id, stockDto);

        return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await repository.DeleteByIdAsync(id);

        return NoContent();
    }
}