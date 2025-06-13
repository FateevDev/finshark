using Asp.Versioning;
using FinShark.API.Dtos.Stock;
using FinShark.API.Exceptions;
using FinShark.API.Mappers;
using FinShark.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers.v1;

[ApiVersion("1.0")]
[ControllerName("stocks")]
[Authorize]
public class StockController(IStockRepository repository) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] StockQueryObject query)
    {
        var stocks = await repository.GetAllAsync(query);
        var stockDtos = stocks.Select(stock => stock.ToStockDto());

        return Ok(stockDtos);
    }

    [HttpGet("{id:int}")]
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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
    {
        var stock = await repository.UpdateAsync(id, stockDto);

        return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await repository.DeleteByIdAsync(id);

        return NoContent();
    }
}