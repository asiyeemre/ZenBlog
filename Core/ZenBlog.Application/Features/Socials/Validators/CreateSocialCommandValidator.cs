using FluentValidation;
using ZenBlog.Application.Features.Socials.Command;

namespace ZenBlog.Application.Features.Socials.Validators;

public class CreateSocialCommandValidator : AbstractValidator<CreateSocialCommand>
{
    public CreateSocialCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık Gerekli.")
            .MaximumLength(100).WithMessage("Başlık 100 karakterden fazla olamaz.");
        RuleFor(x => x.Icon)
            .NotEmpty().WithMessage("İkon gerekli.")
            .MaximumLength(100).WithMessage("İkon 100 karakterden fazla olamaz.");
        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Url gerekli.")
            .MaximumLength(200).WithMessage("Url 200 karakterden fazla olamaz.");
    }
}
