using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Command;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers;

public class UpdateSocialCommandHandler(IRepository<Social> repository,IMapper mapper,IUnitOfWork unitOfWork): IRequestHandler<UpdateSocialCommand,BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
    {
        var socialEntity = await repository.GetByIdAsync(request.Id);
        if (socialEntity == null)
        {
            return BaseResult<object>.Fail("Sosyal medya bulunamadı");
        }

        mapper.Map<Social>(request);
        repository.Update(socialEntity);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Sosyal medya başarıyla güncellendi");


    }
}
