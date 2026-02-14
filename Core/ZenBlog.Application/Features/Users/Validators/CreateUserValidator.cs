using FluentValidation;
using ZenBlog.Application.Features.Users.Commands;

namespace ZenBlog.Application.Features.Users.Validators;

public class CreateUserValidator:AbstractValidator<CreateUserCommand>
{

    public CreateUserValidator() {

        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Adınızı girmeniz gereklidir.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyadınızı girmeniz gereklidir.");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adınızı girmeniz gereklidir.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresinizi girmeniz gereklidir.").EmailAddress().WithMessage("Email adresiniz geçersizdir.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrenizi girmeniz gereklidir.");

    }
}
