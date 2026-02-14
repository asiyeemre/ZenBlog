using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Categories.Commands;

namespace ZenBlog.Application.Features.Categories.Validators;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Gereklidir. ").MinimumLength(3).WithMessage("Kategori ismi en az 3 karakterli olmalı.");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Kategori Id'si gereklidir.");
    }
}
