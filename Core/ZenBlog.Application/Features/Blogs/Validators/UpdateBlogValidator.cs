using FluentValidation;
using ZenBlog.Application.Features.Blogs.Commands;

namespace ZenBlog.Application.Features.Blogs.Validators;

public class UpdateBlogValidator:AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş bırakılamaz.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
        RuleFor(x => x.CoverImage).NotEmpty().WithMessage("Kapak fotoğrafı boş bırakılamaz.");
        RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog fotoğrafı boş bırakılamaz.");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori boş bırakılamaz.");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı boş bırakılamaz.");
    }
}
