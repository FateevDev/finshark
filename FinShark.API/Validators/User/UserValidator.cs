using System.Linq.Expressions;
using FinShark.API.Dtos.User;
using FluentValidation;

namespace FinShark.API.Validators.User;

public abstract class StockBaseValidator<T> : AbstractValidator<T>
{
    private const int UsernameMinLength = 4;
    private const int UsernameMaxLength = 30;

    protected void SetupUsernameRules(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(UsernameMinLength)
            .WithMessage($"Username must be at least {UsernameMinLength} characters.")
            .MaximumLength(UsernameMaxLength)
            .WithMessage($"Username must be less than {UsernameMaxLength} characters.");
    }

    protected void SetupEmailRules(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email must be valid.");
    }

    protected void SetupPasswordRules(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty();
    }
}

public class UserRegisterValidator : StockBaseValidator<UserRegisterDto>
{
    public UserRegisterValidator()
    {
        SetupUsernameRules(dto => dto.Username);
        SetupEmailRules(dto => dto.Email);
        SetupPasswordRules(dto => dto.Password);
    }
}

public class UserLoginValidator : StockBaseValidator<UserLoginDto>
{
    public UserLoginValidator()
    {
        RuleFor(dto => dto.Username)
            .NotEmpty()
            .WithMessage("Username is required.");
        RuleFor(dto => dto.Password)
            .NotEmpty()
            .WithMessage("Password is required.");
    }
}