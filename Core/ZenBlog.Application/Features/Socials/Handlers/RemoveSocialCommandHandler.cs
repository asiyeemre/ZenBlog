using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Command;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers;

public class RemoveSocialCommandHandler(IRepository<Social> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveSocialCommand, BaseResult<object>>
{

        
public async Task<BaseResult<object>> Handle(RemoveSocialCommand request, CancellationToken cancellationToken)
    {
        var socialEntity = await repository.GetByIdAsync(request.Id);
        if (socialEntity == null)
        {
            return BaseResult<object>.Fail("Sosyal medya bulunamadı");
        }
        repository.Delete(socialEntity);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Sosyal medya başarıyla silindi");
    }
}
