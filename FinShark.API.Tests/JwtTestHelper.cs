using System.IdentityModel.Tokens.Jwt;

public static class JwtTestHelper
{
    public static JwtSecurityToken DecodeToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.ReadJwtToken(token);
    }
}