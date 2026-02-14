using FluentValidation;
using ZenBlog.Application.Features.ContactInfos.Commands;

namespace ZenBlog.Application.Features.ContactInfos.Validators;

public class UpdateContactInfoValidator : AbstractValidator<UpdateContactInfoCommand>
{
    public UpdateContactInfoValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez")
                              .EmailAddress().WithMessage("Geçersiz email formatı");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş geçilemez");
                                 
        RuleFor(x => x.Adress).NotEmpty().WithMessage("Adres alanı boş geçilemez").MaximumLength(200).WithMessage("Adres alanı en fazla 200 karakter olabilir");

        RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Harita URL'si boş geçilemez");
    }

}
