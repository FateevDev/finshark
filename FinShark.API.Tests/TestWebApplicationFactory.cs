using FinShark.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace FinShark.API.Tests;

public class TestWebApplicationFactory : WebApplicationFactory<FinSharkApiServiceProgram>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

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
}