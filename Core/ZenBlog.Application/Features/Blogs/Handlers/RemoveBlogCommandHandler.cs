using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers;

public class RemoveBlogCommandHandler(IRepository<Blog> repository,IUnitOfWork unitOfWork) : IRequestHandler<RemoveBlogCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
    {

        var blog = await repository.GetByIdAsync(request.Id);
        if (blog == null) 
        {
            return BaseResult<object>.NotFound("Blog Bulunamadı");
        }
        repository.Delete(blog);
        await unitOfWork.SaveChangesAsync();

        return BaseResult<object>.Success("Blog başarılı bir şekilde silindi");
    }
}
