using Asp.Versioning;
using FinShark.API.Exceptions;
using FinShark.API.Extensions;
using FinShark.API.Mappers;
using FinShark.API.Models;
using FinShark.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers.v1;

[ApiVersion("1.0")]
[ControllerName("portfolio")]
[Authorize]
public class PortfolioController(UserManager<User> userManager, IStockRepository stockRepository) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetUserPortfolios()
    {
        try
        {
            var userId = User.GetUserId();
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userPortfolio = user.Portfolios.Select(portfolio => portfolio.ToDto());

            return Ok(userPortfolio);
        }
        catch (EntityNotFoundException<string>)
        {
            return NotFound("User not found");
        }
    }
}