using FluentValidation;
using ZenBlog.Application.Features.ContactInfos.Commands;

namespace ZenBlog.Application.Features.ContactInfos.Validators;

public class CreateContactInfoValidator : AbstractValidator<CreateContactInfoCommand>
{
    public CreateContactInfoValidator()
    {
        RuleFor(x=>x.Adress).NotEmpty().WithMessage("Adres boş olamaz.").MaximumLength(200).WithMessage("Adres en fazla 200 karakter olabilir.");
        RuleFor(x=>x.Email).NotEmpty().WithMessage("Email boş olamaz.").EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş olamaz.");
        RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Map URL boş olamaz.");

    }

}
