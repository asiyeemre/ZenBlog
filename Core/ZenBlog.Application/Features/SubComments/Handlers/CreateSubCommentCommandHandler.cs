using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers;

public class CreateSubCommentCommandHandler(IRepository<SubComment> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateSubCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateSubCommentCommand request, CancellationToken cancellationToken)
    {
        var subcomment=mapper.Map<SubComment>(request);
        await repository.CreateAsync(subcomment);
        await unitOfWork.SaveChangesAsync();

        return BaseResult<object>.Success(subcomment);

    }
}
