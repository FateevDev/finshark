using System.IdentityModel.Tokens.Jwt;

namespace FinShark.API.Tests;

public static class JwtTestHelper
{
    public static JwtSecurityToken DecodeToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.ReadJwtToken(token);
    }
}