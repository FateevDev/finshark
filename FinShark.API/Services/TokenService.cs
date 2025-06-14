using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinShark.API.Configuration;
using FinShark.API.Models;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace FinShark.API.Services;

public class TokenService(JwtSettings jwtSettings) : ITokenService
{
    private const int TokenExpirationInDays = 3;

    private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(jwtSettings.SigningKey));

    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.GivenName, user.UserName!)
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(TokenExpirationInDays),
            SigningCredentials = creds,
            Issuer = jwtSettings.Issuer,
            Audience = jwtSettings.Audience
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}