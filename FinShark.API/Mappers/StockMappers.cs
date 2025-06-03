using FinShark.API.Dtos.Stock;
using FinShark.API.Models;

namespace FinShark.API.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto(
            stockModel.Id,
            stockModel.Symbol,
            stockModel.CompanyName,
            stockModel.Purchase,
            stockModel.LastDiv,
            stockModel.Industry,
            stockModel.MarketCap
        );
    }

    public static Stock ToStockFromCreateRequest(this CreateStockRequestDto stockDto)
    {
        return new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
        };
    }

    public static void UpdateFromRequest(this Stock stock, UpdateStockRequestDto stockDto)
    {
        stock.Symbol = stockDto.Symbol;
        stock.CompanyName = stockDto.CompanyName;
        stock.Purchase = stockDto.Purchase;
        stock.LastDiv = stockDto.LastDiv;
        stock.Industry = stockDto.Industry;
        stock.MarketCap = stockDto.MarketCap;
    }
}