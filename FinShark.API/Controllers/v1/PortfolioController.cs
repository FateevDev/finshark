using Asp.Versioning;
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
    IPortfolioRepository portfolioRepository
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
}