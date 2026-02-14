using FluentValidation;
using ZenBlog.Application.Features.Comments.Commands;

namespace ZenBlog.Application.Features.Comments.Validators;

public class UpdateCommentValidator:AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Gereklidir. ");
        RuleFor(x => x.BlogId).NotEmpty().WithMessage("Blog Gereklidir. ");
        RuleFor(x => x.Body).NotEmpty().WithMessage("Mesaj içeriği Gereklidir.");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Gereklidir.");
    }

}
