using FinShark.API.Configuration;
using FinShark.API.Helpers;
using FinShark.API.Models;
using FinShark.API.Services;
using JetBrains.Annotations;
using Xunit;

namespace FinShark.API.Tests.Services;

[TestSubject(typeof(TokenService))]
public class TokenServiceTest
{
    [Fact]
    public void CreateToken_WhenCalled_ReturnsToken()
    {
        //Arrange
        var dateTime = DateTime.UtcNow;
        var jwtSettings = new JwtSettings(
            issuer: "http://localhost",
            audience: "http://localhost",
            signingKey: "2D4g3KrC8zA9XpQ5vM7tN1jL6wY0bE55"
        );
        var sut = new TokenService(jwtSettings, new FakeDateTimeProvider(dateTime));
        var user = GenerateUser();

        //Act
        var token = sut.CreateToken(user);

        //Assert
        var decodedToken = JwtTestHelper.DecodeToken(token);

        Assert.Contains(decodedToken.Claims, c => c.Type == "given_name");
        Assert.Contains(decodedToken.Claims, c => c.Type == "email");
        Assert.Contains(decodedToken.Claims, c => c.Type == "nameid");

        var usernameClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "given_name");
        var emailClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "email");
        var idClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "nameid");
        var issuer = decodedToken.Claims.FirstOrDefault(c => c.Type == "iss");
        var audience = decodedToken.Claims.FirstOrDefault(c => c.Type == "aud");

        Assert.Equal(user.UserName, usernameClaim?.Value);
        Assert.Equal(user.Email, emailClaim?.Value);
        Assert.Equal(user.Id, idClaim?.Value);
        Assert.Equal(jwtSettings.Issuer, issuer?.Value);
        Assert.Equal(jwtSettings.Audience, audience?.Value);

        var tokenExpirationInDays = 3;

        Assert.Equal(dateTime.AddDays(tokenExpirationInDays), decodedToken.ValidTo, TimeSpan.FromSeconds(1)
        );
    }

    private static User GenerateUser()
    {
        return new User { Email = "some@email.com", UserName = "test", Id = Guid.NewGuid().ToString() };
    }
}