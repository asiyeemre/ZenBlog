using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers;

public class GetCommentsQueryHandler(IRepository<Comment> repository,IMapper mapper) : IRequestHandler<GetCommentsQuery, BaseResult<List<GetCommentsQueryResult>>>
{
    public async Task<BaseResult<List<GetCommentsQueryResult>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetAllAsync();
        var comments=mapper.Map<List<GetCommentsQueryResult>>(values);
        return  BaseResult<List<GetCommentsQueryResult>>.Success(comments);
        
    }
}
