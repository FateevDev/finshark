using Microsoft.AspNetCore.Identity;

namespace FinShark.API.Models;

public class User : IdentityUser
{
    public List<Portfolio> Portfolios { get; set; } = new();
}