

using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entities;


namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> repository,IMapper mapper):IRequestHandler<GetCategoryByIdQuery,BaseResult<GetCategoryByIdQueryResult>>
    {

        async Task<BaseResult<GetCategoryByIdQueryResult>> IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResult>>.Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category=await repository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return BaseResult<GetCategoryByIdQueryResult>.NotFound("Kategori Bulunamadı");
            }

            var response=mapper.Map<GetCategoryByIdQueryResult>(category);

            return BaseResult<GetCategoryByIdQueryResult>.Success(response);
        }
    }
}
