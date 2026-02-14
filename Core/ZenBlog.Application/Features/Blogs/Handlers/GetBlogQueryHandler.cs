using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers;

public class GetBlogQueryHandler(IRepository<Blog> repository,IMapper mapper): IRequestHandler<GetBlogsQuery, BaseResult<List<GetBlogsQueryResult>>>
{
    public async Task<BaseResult<List<GetBlogsQueryResult>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = await repository.GetAllAsync();
        var response=mapper.Map<List<GetBlogsQueryResult>>(blogs);
        return BaseResult<List<GetBlogsQueryResult>>.Success(response);

    }
}
