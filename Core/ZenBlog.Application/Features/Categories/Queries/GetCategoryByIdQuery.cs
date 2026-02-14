using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;

namespace ZenBlog.Application.Features.Categories.Queries;

public record GetCategoryByIdQuery(Guid Id) : IRequest<BaseResult<GetCategoryByIdQueryResult>>;

//Değiştirilemez özelliklere sahip nesneler olusturmak için record kullanılır. 
//Özellik değerleri sadece constructor içinde atanabilir. 
