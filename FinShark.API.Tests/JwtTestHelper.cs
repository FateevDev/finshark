using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public static class JwtTestHelper
{
    public static ClaimsPrincipal ValidateToken(string token, string secretKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);
        
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false, // В тестах можем отключить
            ValidateAudience = false, // В тестах можем отключить
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

        return principal;
    }
    
    public static JwtSecurityToken DecodeToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.ReadJwtToken(token);
    }
}
