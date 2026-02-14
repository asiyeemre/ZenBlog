using FluentValidation;
using ZenBlog.Application.Features.Messages.Commands;

namespace ZenBlog.Application.Features.Messages.Validators;

public class CreateMessageValidator:AbstractValidator<CreateMessageCommand>
{
    public CreateMessageValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İsim Gerekli.")
            .MaximumLength(100).WithMessage("İsim 100 karakterden fazla olamaz");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email Gerekli.")
            .EmailAddress().WithMessage("Geçerli bir email gereklidir.")
            .MaximumLength(100).WithMessage("Email 100 karakterden fazla olamaz.");
        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Konu Gerekli.")
            .MaximumLength(150).WithMessage("Konu 150 karakterden fazla olamaz.");
        RuleFor(x => x.MessageBody)
            .NotEmpty().WithMessage("Mesaj içeriği gereklidir.")
            .MaximumLength(2000).WithMessage("Mesaj içeriği 2000 karakterden fazla olamaz.");






    }









}
