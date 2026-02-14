
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers;

public class RemoveCategoryCommandHandler(IRepository<Category> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.id);
        if (category == null)
        {
            return BaseResult<bool>.NotFound("Kategori Bulunamadı");
        }

        repository.Delete(category);
        var response = await unitOfWork.SaveChangesAsync();
        return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Kategori Silinemedi.");


        // var category = mapper.Map<Category>(request);
        // repository.DeleteAsync(category);
        // var result = await unitOfWork.SaveChangesAsync();

        //return result ? BaseResult<bool>.Success(result) : BaseResult<bool>.Fail("Veri Silinemedi.");
    }
}
