using Asp.Versioning;
using FinShark.API.Dtos.User;
using FinShark.API.Mappers;
using FinShark.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.API.Controllers.v1;

[ApiVersion("1.0")]
[ControllerName("account")]
public class AccountController(UserManager<User> userManager) : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    {
        try
        {
            var user = dto.ToUserFromRegisterDto();
            var createdUser = await userManager.CreateAsync(user, dto.Password);

            if (!createdUser.Succeeded)
            {
                return StatusCode(500, createdUser.Errors);
            }

            var roleResult = await userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
            {
                return StatusCode(500, roleResult.Errors);
            }

            return Ok("User created successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}