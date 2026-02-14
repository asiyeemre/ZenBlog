using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers;

public class UpdateContactInfoCommandHandler(IRepository<ContactInfo> repository,IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<UpdateContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
    {
        var contactInfo= mapper.Map<ContactInfo>(request);
        repository.Update(contactInfo);
        await unitOfWork.SaveChangesAsync();

        return BaseResult<object>.Success("İletişim Bilgileri Başarıyla Güncellendi");


    }
}
