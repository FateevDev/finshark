using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FinShark.API.Controllers.v1;
using FinShark.API.Data;
using FinShark.API.Dtos.Stock;
using FinShark.API.Models;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FinShark.API.Tests.Controllers.v1;

[TestSubject(typeof(StockController))]
public class StockControllerTest : IClassFixture<TestWebApplicationFactory>, IAsyncLifetime
{
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;
    private string _authToken = string.Empty;

    public StockControllerTest(TestWebApplicationFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    public async ValueTask InitializeAsync()
    {
        await _factory.InitializeDatabaseAsync(TestContext.Current.CancellationToken);
        _authToken = await _factory.CreateUserAndGetTokenAsync();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
    }

    public ValueTask DisposeAsync()
    {
        _client?.Dispose();
        return ValueTask.CompletedTask;
    }

    #region GET /api/v1/stocks

    [Fact]
    public async Task GetAll_WithoutFilters_ReturnsAllStocks()
    {
        // Arrange
        await SeedTestStocksAsync();

        // Act
        var response = await _client.GetAsync("/api/v1/stocks", TestContext.Current.CancellationToken);

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var stocks = JsonSerializer.Deserialize<StockDto[]>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.NotNull(stocks);
        Assert.True(stocks.Length >= 2);
    }

    [Fact]
    public async Task GetAll_WithSymbolFilter_ReturnsFilteredStocks()
    {
        // Arrange
        await SeedTestStocksAsync();

        // Act
        var response = await _client.GetAsync("/api/v1/stocks?Symbol=AAPL", TestContext.Current.CancellationToken);

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var stocks = JsonSerializer.Deserialize<StockDto[]>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.NotNull(stocks);
        Assert.All(stocks, stock => Assert.Contains("AAPL", stock.Symbol));
    }

    [Fact]
    public async Task GetAll_WithLimitAndOffset_ReturnsPaginatedResults()
    {
        // Arrange
        await SeedTestStocksAsync();

        // Act
        var response = await _client.GetAsync("/api/v1/stocks?Limit=1&Offset=0", TestContext.Current.CancellationToken);

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var stocks = JsonSerializer.Deserialize<StockDto[]>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.NotNull(stocks);
        Assert.Single(stocks);
    }

    [Fact]
    public async Task GetAll_WithoutAuthentication_ReturnsUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;

        // Act
        var response = await _client.GetAsync("/api/v1/stocks", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    #endregion

    #region GET /api/v1/stocks/{id}

    [Fact]
    public async Task GetById_WithValidId_ReturnsStock()
    {
        // Arrange
        var stockId = await CreateTestStockAsync();

        // Act
        var response = await _client.GetAsync($"/api/v1/stocks/{stockId}", TestContext.Current.CancellationToken);

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var stock = JsonSerializer.Deserialize<StockDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.NotNull(stock);
        Assert.Equal(stockId, stock.Id);
        Assert.Equal("TEST", stock.Symbol);
    }

    [Fact]
    public async Task GetById_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/stocks/999999", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetById_WithoutAuthentication_ReturnsUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;
        var stockId = await CreateTestStockAsync();

        // Act
        var response = await _client.GetAsync($"/api/v1/stocks/{stockId}", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    #endregion

    #region POST /api/v1/stocks

    [Fact]
    public async Task Create_WithValidData_ReturnsCreated()
    {
        // Arrange
        var createDto = new CreateStockRequestDto(
            Symbol: "NVDA",
            CompanyName: "NVIDIA Corporation",
            Purchase: 450.50m,
            LastDiv: 0.16m,
            Industry: "Technology",
            MarketCap: 1100000000000
        );

        var json = JsonSerializer.Serialize(createDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/v1/stocks", content, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var responseContent = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var stock = JsonSerializer.Deserialize<StockDto>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.NotNull(stock);
        Assert.Equal("NVDA", stock.Symbol);
        Assert.Equal("NVIDIA Corporation", stock.CompanyName);
        Assert.True(stock.Id > 0);

        // Проверяем заголовок Location
        Assert.NotNull(response.Headers.Location);
    }

    [Fact]
    public async Task Create_WithInvalidData_ReturnsBadRequest()
    {
        // Arrange - отправляем пустой JSON
        var content = new StringContent("{}", Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/v1/stocks", content, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_WithoutAuthentication_ReturnsUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;
        var createDto = new CreateStockRequestDto(
            Symbol: "TEST",
            CompanyName: "Test Company",
            Purchase: 100m,
            LastDiv: 1m,
            Industry: "Test",
            MarketCap: 1000000
        );

        var json = JsonSerializer.Serialize(createDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/v1/stocks", content, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    #endregion

    #region PUT /api/v1/stocks/{id}

    [Fact]
    public async Task Update_WithValidData_ReturnsOk()
    {
        // Arrange
        var stockId = await CreateTestStockAsync();
        var updateDto = new UpdateStockRequestDto(
            Symbol: "TEST_UPDATED",
            CompanyName: "Test Company Updated",
            Purchase: 200m,
            LastDiv: 2m,
            Industry: "Technology Updated",
            MarketCap: 2000000
        );

        var json = JsonSerializer.Serialize(updateDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response =
            await _client.PutAsync($"/api/v1/stocks/{stockId}", content, TestContext.Current.CancellationToken);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        var stock = JsonSerializer.Deserialize<StockDto>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.NotNull(stock);
        Assert.Equal("TEST_UPDATED", stock.Symbol);
        Assert.Equal("Test Company Updated", stock.CompanyName);
        Assert.Equal(200m, stock.Purchase);
    }

    [Fact]
    public async Task Update_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        var updateDto = new UpdateStockRequestDto(
            Symbol: "TEST",
            CompanyName: "Test",
            Purchase: 100m,
            LastDiv: 1m,
            Industry: "Test",
            MarketCap: 1000000
        );

        var json = JsonSerializer.Serialize(updateDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync("/api/v1/stocks/999999", content, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Update_WithoutAuthentication_ReturnsUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;
        var stockId = await CreateTestStockAsync();
        var updateDto = new UpdateStockRequestDto(
            Symbol: "TEST",
            CompanyName: "Test",
            Purchase: 100m,
            LastDiv: 1m,
            Industry: "Test",
            MarketCap: 1000000
        );

        var json = JsonSerializer.Serialize(updateDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response =
            await _client.PutAsync($"/api/v1/stocks/{stockId}", content, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    #endregion

    #region DELETE /api/v1/stocks/{id}

    [Fact]
    public async Task Delete_WithValidId_ReturnsNoContent()
    {
        // Arrange
        var stockId = await CreateTestStockAsync();

        // Act
        var response = await _client.DeleteAsync($"/api/v1/stocks/{stockId}", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        // Проверяем, что акция действительно удалена
        var getResponse = await _client.GetAsync($"/api/v1/stocks/{stockId}", TestContext.Current.CancellationToken);
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [Fact]
    public async Task Delete_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.DeleteAsync("/api/v1/stocks/999999", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Delete_WithoutAuthentication_ReturnsUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;
        var stockId = await CreateTestStockAsync();

        // Act
        var response = await _client.DeleteAsync($"/api/v1/stocks/{stockId}", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    #endregion

    #region Helper Methods

    private async Task<int> CreateTestStockAsync()
    {
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var stock = new Stock
        {
            Symbol = "TEST",
            CompanyName = "Test Company",
            Purchase = 100m,
            LastDiv = 1m,
            Industry = "Technology",
            MarketCap = 1000000
        };

        context.Stocks.Add(stock);
        await context.SaveChangesAsync(TestContext.Current.CancellationToken);
        return stock.Id;
    }

    private async Task SeedTestStocksAsync()
    {
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Проверяем, не добавлены ли уже тестовые акции
        if (context.Stocks.Any(s => s.Symbol == "AAPL" || s.Symbol == "GOOGL"))
            return;

        var stocks = new[]
        {
            new Stock
            {
                Symbol = "AAPL",
                CompanyName = "Apple Inc.",
                Purchase = 150m,
                LastDiv = 0.88m,
                Industry = "Technology",
                MarketCap = 2500000000000
            },
            new Stock
            {
                Symbol = "GOOGL",
                CompanyName = "Alphabet Inc.",
                Purchase = 2800m,
                LastDiv = 0m,
                Industry = "Technology",
                MarketCap = 1800000000000
            }
        };

        context.Stocks.AddRange(stocks);
        await context.SaveChangesAsync(TestContext.Current.CancellationToken);
    }

    #endregion
}