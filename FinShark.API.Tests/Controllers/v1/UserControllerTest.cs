using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FinShark.API.Controllers.v1;
using FinShark.API.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
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
    public async Task Login_ValidCredentials_ReturnsSuccess()
    {
        // Arrange
        var username = "loginTestUser";
        var email = $"logintest_{Guid.NewGuid():N}@example.com";
        var password = "TestPassword123!";

        // Сначала создаем пользователя в базе данных
        await CreateUserInDatabaseAsync(username, email, password);

        var loginDto = new
        {
            Username = username,
            Password = password
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/v1/user/login",
            loginDto,
            cancellationToken: TestContext.Current.CancellationToken
        );

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var jsonContent = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var jsonDocument = JsonDocument.Parse(jsonContent);

        Assert.True(jsonDocument.RootElement.TryGetProperty("token", out var tokenProperty));
        Assert.True(jsonDocument.RootElement.TryGetProperty("userName", out var usernameProperty));
        Assert.True(jsonDocument.RootElement.TryGetProperty("email", out var emailProperty));

        // Проверяем значения
        Assert.Equal(username, usernameProperty.GetString());
        Assert.Equal(email, emailProperty.GetString());
        Assert.False(string.IsNullOrEmpty(tokenProperty.GetString()));
    }
    
    [Fact]
    public async Task Login_InvalidUsername_ReturnsUnauthorized()
    {
        // Arrange
        var loginDto = new
        {
            Username = "nonexistentuser",
            Password = "TestPassword123!"
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/v1/user/login",
            loginDto,
            cancellationToken: TestContext.Current.CancellationToken
        );

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Login_InvalidPassword_ReturnsUnauthorized()
    {
        // Arrange
        var username = "invalidPasswordTestUser";
        var email = $"invalidpasstest_{Guid.NewGuid():N}@example.com";
        var password = "TestPassword123!";
        var wrongPassword = "WrongPassword123!";

        // Создаем пользователя в базе данных
        await CreateUserInDatabaseAsync(username, email, password);

        var loginDto = new
        {
            Username = username,
            Password = wrongPassword
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/v1/user/login",
            loginDto,
            cancellationToken: TestContext.Current.CancellationToken
        );

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
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

    /// <summary>
    /// Создает пользователя в базе данных для тестирования
    /// </summary>
    private async Task CreateUserInDatabaseAsync(string username, string email, string password)
    {
        using var scope = _factory.Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var user = new User
        {
            UserName = username,
            Email = email
        };

        var createResult = await userManager.CreateAsync(user, password);
        Assert.True(createResult.Succeeded,
            $"Failed to create user: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");

        // Добавляем роль пользователю
        await userManager.AddToRoleAsync(user, "User");
    }
}