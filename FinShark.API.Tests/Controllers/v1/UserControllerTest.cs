using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FinShark.API.Controllers.v1;
using JetBrains.Annotations;
using Xunit;

namespace FinShark.API.Tests.Controllers.v1;

[TestSubject(typeof(UserController))]
public class UserControllerTest : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly TestWebApplicationFactory _factory;

    public UserControllerTest(TestWebApplicationFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();

        _factory.InitializeDatabaseAsync().GetAwaiter().GetResult();
    }

    [Fact]
    public async Task Register_ValidUser_ReturnsSuccess()
    {
        // Arrange
        var Username = "testuser";
        var Email = $"test_{Guid.NewGuid():N}@example.com";
        var registerDto = new
        {
            Username = Username,
            Email = Email,
            Password = "TestPassword123!"
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/v1/user/register",
            registerDto,
            cancellationToken: TestContext.Current.CancellationToken
        );

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var jsonContent = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken
        );
        var jsonDocument = JsonDocument.Parse(jsonContent);

        Assert.True(jsonDocument.RootElement.TryGetProperty("token", out var tokenProperty));
        Assert.True(jsonDocument.RootElement.TryGetProperty("userName", out var usernameProperty));
        Assert.True(jsonDocument.RootElement.TryGetProperty("email", out var emailProperty));

        // Проверяем значения
        Assert.Equal(registerDto.Username, usernameProperty.GetString());
        Assert.Equal(registerDto.Email, emailProperty.GetString());
        Assert.False(string.IsNullOrEmpty(tokenProperty.GetString()));

        // Декодируем токен без валидации подписи (для проверки структуры)
        var decodedToken = JwtTestHelper.DecodeToken(tokenProperty.ToString());

        // Проверяем claims
        Assert.Contains(decodedToken.Claims, c => c.Type == "given_name");
        Assert.Contains(decodedToken.Claims, c => c.Type == "email");
        Assert.Contains(decodedToken.Claims, c => c.Type == "nameid");

        // Проверяем значения claims
        var usernameClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "given_name");
        var emailClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "email");

        Assert.Equal(Username, usernameClaim?.Value);
        Assert.Equal(Email, emailClaim?.Value);

        // Проверяем срок действия
        Assert.True(decodedToken.ValidTo > DateTime.UtcNow);
    }
}