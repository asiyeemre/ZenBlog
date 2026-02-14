using FluentValidation;
using ZenBlog.Application.Features.Categories.Commands;


namespace ZenBlog.Application.Features.Categories.Validators
{
    public class CreateCategoryValidator :AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator() {

            RuleFor(x => x.categoryName).NotEmpty().WithMessage("Kategori Adı Gereklidir. ").MinimumLength(3).WithMessage("Kategori ismi en az 3 karakterli olmalı.");
        }
    }
}
