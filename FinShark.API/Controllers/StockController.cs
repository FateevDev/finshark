using FinShark.API.Data;
using FinShark.API.Dtos.Stock;
using FinShark.API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Controllers;

[ApiController]
[Route("api/stock")]
public class StockController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public StockController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stocks = await _dbContext.Stocks.ToListAsync();
        var stockDtos = stocks.Select(stock => stock.ToStockDto());

        return Ok(stockDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _dbContext.Stocks.FindAsync(id);

        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        var stock = stockDto.ToStockFromCreateRequest();
        await _dbContext.Stocks.AddAsync(stock);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
    {
        var stock = await _dbContext.Stocks.FindAsync(id);

        if (stock == null)
        {
            return NotFound();
        }

        stock.UpdateFromRequest(stockDto);
        await _dbContext.SaveChangesAsync();

        return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var stock = await _dbContext.Stocks.FindAsync(id);

        if (stock == null)
        {
            return NotFound();
        }

        _dbContext.Stocks.Remove(stock);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}