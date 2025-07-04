using System.Security.Claims;
using FinShark.API.Exceptions;
using FinShark.API.Models;

namespace FinShark.API.Extensions;

public static class ClaimsExtensions
{
    public static string GetUserId(this ClaimsPrincipal user)
    {
        var nameIdentifier = ClaimTypes.NameIdentifier;
        var userId = user.FindFirst(nameIdentifier)?.Value;

        if (userId == null)
        {
            throw new EntityNotFoundException<string>(nameof(User), nameIdentifier);
        }

        return userId;
    }
    
    public static string GetUserName(this ClaimsPrincipal user)
    {
        var givenName = ClaimTypes.GivenName;
        var userName = user.FindFirst(givenName)?.Value;

        if (userName == null)
        {
            throw new EntityNotFoundException<string>(nameof(User), givenName);
        }

        return userName;
    }
}