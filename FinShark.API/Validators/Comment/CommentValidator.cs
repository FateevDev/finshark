using System.Linq.Expressions;
using FinShark.API.Dtos.Comment;
using FluentValidation;

namespace FinShark.API.Validators.Comment;

public abstract class CommentBaseValidator<T> : AbstractValidator<T>
{
    private const int TitleMinLength = 5;
    private const int TitleMaxLength = 255;
    private const int ContentMinLength = 10;
    private const int ContentMaxLength = 4000;

    protected void SetupTitleRules(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(TitleMinLength).WithMessage($"Title must be at least {TitleMinLength} characters.")
            .MaximumLength(TitleMaxLength).WithMessage($"Title must be less than {TitleMaxLength} characters.");
    }

    protected void SetupContentRules(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(ContentMinLength).WithMessage($"Content must be at least {ContentMinLength} characters.")
            .MaximumLength(ContentMaxLength).WithMessage($"Content must be less than {ContentMaxLength} characters.");
    }
}

public class CommentCreateValidator : CommentBaseValidator<CreateCommentRequestDto>
{
    public CommentCreateValidator()
    {
        SetupTitleRules(dto => dto.Title);
        SetupContentRules(dto => dto.Content);
    }
}

public class CommentUpdateValidator : CommentBaseValidator<UpdateCommentRequestDto>
{
    public CommentUpdateValidator()
    {
        SetupTitleRules(dto => dto.Title);
        SetupContentRules(dto => dto.Content);
    }
}