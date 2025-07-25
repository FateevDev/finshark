using FinShark.API.Data;
using FinShark.API.Helpers;
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
    private readonly string _databaseName = Guid.NewGuid().ToString();

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

            // Каждый экземпляр factory получает уникальную БД
            services.AddDbContext<ApplicationDbContext>(options => 
            { 
                options.UseInMemoryDatabase(_databaseName); 
            });

            // Регистрируем реализацию IDateTimeProvider
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            // Отключаем логирование для более чистого вывода тестов
            services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Warning));
        });
    }

    public async Task InitializeDatabaseAsync(CancellationToken cancellationToken = default)
    {
        using var scope = Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Обеспечиваем создание БД
        await context.Database.EnsureCreatedAsync(cancellationToken);

        // Создаем роли
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }
    }

    public async Task<string> CreateUserAndGetTokenAsync(string email = "test@example.com",
        string password = "Test123!@#$11")
    {
        using var scope = Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();

        var user = new User
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Failed to create test user: {result.Errors.First().Description}");
        }

        await userManager.AddToRoleAsync(user, "User");

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