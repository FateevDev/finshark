using System.Linq.Expressions;
using FinShark.API.Dtos.Portfolio;
using FluentValidation;

namespace FinShark.API.Validators.Portfolio;

public class PortfolioAddValidator : AbstractValidator<CreatePortfolioRequestDto>
{
    private const int QuantityMinCount = 1;
    private const int PurchasePriceMinCount = 0;

    public PortfolioAddValidator()
    {
        RuleFor(dto => dto.Quantity)
            .GreaterThanOrEqualTo(QuantityMinCount)
            .WithMessage($"Quantity must be at least {QuantityMinCount}.");
        RuleFor(dto => dto.PurchasePrice)
            .GreaterThan(PurchasePriceMinCount)
            .WithMessage($"Purchase price must be at least {PurchasePriceMinCount}.");
    }
}