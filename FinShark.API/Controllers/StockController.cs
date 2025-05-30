using FinShark.API.Data;
using FinShark.API.Dtos.Stock;
using FinShark.API.Mappers;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        var stocks = _dbContext.Stocks
            .ToList()
            .Select(stock => stock.ToStockDto());

        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var stock = _dbContext.Stocks.Find(id);

        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
    {
        var stock = stockDto.ToStockFromCreateRequest();
        _dbContext.Stocks.Add(stock);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
    {
        var stock = _dbContext.Stocks.Find(id);

        if (stock == null)
        {
            return NotFound();
        }

        stock.UpdateFromRequest(stockDto);
        _dbContext.SaveChanges();

        return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var stock = _dbContext.Stocks.Find(id);

        if (stock == null)
        {
            return NotFound();
        }

        _dbContext.Stocks.Remove(stock);
        _dbContext.SaveChanges();

        return NoContent();
    }
}