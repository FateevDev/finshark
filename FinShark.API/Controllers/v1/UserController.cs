using Asp.Versioning;
using FinShark.API.Dtos.User;
using FinShark.API.Mappers;
using FinShark.API.Models;
using FinShark.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers.v1;

[ApiVersion("1.0")]
[ControllerName("user")]
public class UserController(UserManager<User> userManager, ITokenService tokenService) : BaseController
{
    // public async Task<IActionResult> GetById([FromRoute] int id)
    // {
    //     
    // }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    {
        try
        {
            var user = dto.ToUserFromRegisterDto();
            var createdUser = await userManager.CreateAsync(user, dto.Password);

            if (!createdUser.Succeeded)
            {
                foreach (var error in createdUser.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem(ModelState);
            }

            var roleResult = await userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
            {
                foreach (var error in createdUser.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem(ModelState);
            }

            return Created("", user.ToUserCreatedDto(tokenService.CreateToken(user)));
        }
        catch (Exception e)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: e.Message);
        }
    }
}