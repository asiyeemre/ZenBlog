using FluentValidation;
using ZenBlog.Application.Features.SubComments.Commands;

namespace ZenBlog.Application.Features.SubComments.Validators;

public class CreateSubCommentValidator:AbstractValidator<CreateSubCommentCommand>
{
    public CreateSubCommentValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı girilmeli.");
        RuleFor(x => x.CommentId).NotEmpty().WithMessage("Yorum yapacağınız yorumun Id si girilmeli.");
        RuleFor(x => x.Body).NotEmpty().WithMessage("Alt yorum içeriği girilmeli.")
            .MaximumLength(200).WithMessage("Yorum en fazla 200 karakter olmalı");
    }

}
