using System.Linq.Expressions;
using FinShark.API.Dtos.Stock;
using FluentValidation;

namespace FinShark.API.Validators.Stock;

public abstract class StockBaseValidator<T> : AbstractValidator<T>
{
    private const int SymbolMinLength = 1;
    private const int SymbolMaxLength = 10;
    private const int CompanyNameMinLength = 2;
    private const int CompanyNameMaxLength = 100;
    private const int IndustryMinLength = 2;
    private const int IndustryMaxLength = 50;
    private const decimal MinPrice = 0.01m;
    private const decimal MaxPrice = 999999.99m;
    private const long MinMarketCap = 1;
    private const long MaxMarketCap = 9999999999999;

    protected void SetupSymbolRules(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(SymbolMinLength).WithMessage($"Symbol must be at least {SymbolMinLength} characters.")
            .MaximumLength(SymbolMaxLength).WithMessage($"Symbol must be less than {SymbolMaxLength} characters.")
            .Matches("^[A-Z]+$").WithMessage("Symbol must contain only uppercase letters.");
    }

    protected void SetupCompanyNameRules(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(CompanyNameMinLength)
            .WithMessage($"Company name must be at least {CompanyNameMinLength} characters.")
            .MaximumLength(CompanyNameMaxLength)
            .WithMessage($"Company name must be less than {CompanyNameMaxLength} characters.");
    }

    protected void SetupPurchaseRules(Expression<Func<T, decimal>> expression)
    {
        RuleFor(expression)
            .GreaterThanOrEqualTo(MinPrice).WithMessage($"Purchase price must be at least {MinPrice}.")
            .LessThanOrEqualTo(MaxPrice).WithMessage($"Purchase price must be less than or equal to {MaxPrice}.");
    }

    protected void SetupLastDivRules(Expression<Func<T, decimal>> expression)
    {
        RuleFor(expression)
            .GreaterThanOrEqualTo(0).WithMessage("Last dividend must be non-negative.")
            .LessThanOrEqualTo(MaxPrice).WithMessage($"Last dividend must be less than or equal to {MaxPrice}.");
    }

    protected void SetupIndustryRules(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(IndustryMinLength).WithMessage($"Industry must be at least {IndustryMinLength} characters.")
            .MaximumLength(IndustryMaxLength)
            .WithMessage($"Industry must be less than {IndustryMaxLength} characters.");
    }

    protected void SetupMarketCapRules(Expression<Func<T, long>> expression)
    {
        RuleFor(expression)
            .GreaterThanOrEqualTo(MinMarketCap).WithMessage($"Market cap must be at least {MinMarketCap}.")
            .LessThanOrEqualTo(MaxMarketCap).WithMessage($"Market cap must be less than or equal to {MaxMarketCap}.");
    }
}

public class StockCreateValidator : StockBaseValidator<CreateStockRequestDto>
{
    public StockCreateValidator()
    {
        SetupSymbolRules(dto => dto.Symbol);
        SetupCompanyNameRules(dto => dto.CompanyName);
        SetupPurchaseRules(dto => dto.Purchase);
        SetupLastDivRules(dto => dto.LastDiv);
        SetupIndustryRules(dto => dto.Industry);
        SetupMarketCapRules(dto => dto.MarketCap);
    }
}

public class StockUpdateValidator : StockBaseValidator<UpdateStockRequestDto>
{
    public StockUpdateValidator()
    {
        SetupSymbolRules(dto => dto.Symbol);
        SetupCompanyNameRules(dto => dto.CompanyName);
        SetupPurchaseRules(dto => dto.Purchase);
        SetupLastDivRules(dto => dto.LastDiv);
        SetupIndustryRules(dto => dto.Industry);
        SetupMarketCapRules(dto => dto.MarketCap);
    }
}