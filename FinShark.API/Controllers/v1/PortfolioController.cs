using Asp.Versioning;
using FinShark.API.Dtos.Portfolio;
using FinShark.API.Exceptions;
using FinShark.API.Extensions;
using FinShark.API.Mappers;
using FinShark.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers.v1;

[ApiVersion("1.0")]
[ControllerName("portfolio")]
[Authorize]
public class PortfolioController(
    IPortfolioRepository portfolioRepository,
    IStockRepository stockRepository
) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetUserPortfolios()
    {
        try
        {
            var userId = User.GetUserId();
            var portfolios = await portfolioRepository.GetByUserIdAsync(userId);

            return Ok(portfolios.Select(portfolio => portfolio.ToDto()));
        }
        catch (EntityNotFoundException<string>)
        {
            return NotFound("User not found");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUserPortfolio([FromBody] CreatePortfolioRequestDto dto)
    {
        try
        {
            var userId = User.GetUserId();
            var stock = await stockRepository.GetBySymbolAsync(dto.StockSymbol);
            var portfolio = dto.ToPortfolio(userId, stock.Id);

            await portfolioRepository.CreateAsync(portfolio);

            return CreatedAtAction(nameof(GetUserPortfolios), portfolio.ToDto());
        }
        catch (EntityNotFoundException<string> e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{portfolioId:int}")]
    public async Task<IActionResult> RemoveUserPortfolio([FromRoute] int portfolioId)
    {
        try
        {
            await portfolioRepository.DeleteByIdAsync(portfolioId);

            return NoContent();
        }
        catch (EntityNotFoundException<int> exception)
        {
            return NotFound(exception.Message);
        }
    }
}