using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers;

public class RemoveCommentCommandHandler(IRepository<Comment> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<RemoveCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await repository.GetByIdAsync(request.id);
        if (comment == null)
        {
            return BaseResult<object>.NotFound("Yorum Bulunamadı");
        }

        repository.Delete(comment);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Yorum başarılı bir şekilde silindi.");
    }
}
