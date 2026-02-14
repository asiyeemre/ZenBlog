using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers;

public class CreateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<CreateCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment=mapper.Map<Comment>(request);
        await repository.CreateAsync(comment);
        await unitOfWork.SaveChangesAsync();

        return BaseResult<object>.Success(comment);
    }
}
