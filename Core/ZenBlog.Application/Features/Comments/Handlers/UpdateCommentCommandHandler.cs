using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers;

public class UpdateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = mapper.Map<Comment>(request);
        repository.Update(comment);
        await unitOfWork.SaveChangesAsync();

        return BaseResult<object>.Success("Yorum başarılı bir şekilde  güncellendi.");
    }
}
