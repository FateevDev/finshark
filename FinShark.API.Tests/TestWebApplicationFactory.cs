using FinShark.API.Data;
using FinShark.API.Models;
using FinShark.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace FinShark.API.Tests;

public class TestWebApplicationFactory : WebApplicationFactory<FinSharkApiServiceProgram>
{
    private bool _initialized;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.UseSetting("JWT:SigningKey", "test-signing-key-that-is-long-enough-for-hmac-sha256-algorithm");
        builder.UseSetting("JWT:Issuer", "test-issuer");
        builder.UseSetting("JWT:Audience", "test-audience");
        builder.UseSetting("JWT:ExpireDays", "1");

        builder.ConfigureServices(services =>
        {
            // Удаляем реальную БД
            services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));

            // Добавляем in-memory БД
            services.AddDbContext<ApplicationDbContext>(options => { options.UseInMemoryDatabase("TestDb"); });

            // Отключаем логирование для более чистого вывода тестов
            services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Warning));
        });
    }

    public async Task InitializeDatabaseAsync()
    {
        if (_initialized) return;

        using var scope = Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Обеспечиваем создание БД
        await context.Database.EnsureCreatedAsync();

        // Создаем роли
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        _initialized = true;
    }

    public async Task<string> CreateUserAndGetTokenAsync(string email = "test@example.com",
        string password = "Test123!")
    {
        using var scope = Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var tokenService =
            scope.ServiceProvider.GetRequiredService<ITokenService>(); // Предполагаю, что у вас есть такой сервис

        // Создаем пользователя
        var user = new User
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Failed to create test user");
        }

        // Добавляем роль
        await userManager.AddToRoleAsync(user, "User");

        // Генерируем токен
        var token = tokenService.CreateToken(user);
        return token;
    }

    public async Task<User> GetTestUserAsync(string email = "test@example.com")
    {
        using var scope = Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            throw new InvalidOperationException("Test user not found");
        }

        return user;
    }
}