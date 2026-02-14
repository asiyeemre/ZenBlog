using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers;

public class UpdateMessageCommandHandler(IRepository<Message> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateMessageCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var mesaj= await repository.GetByIdAsync(request.Id);
        if (mesaj == null)
        {
            return BaseResult<object>.Fail("Mesaj bulunamadı");
        }
         mapper.Map<Message>(request);
        repository.Update(mesaj);
        await unitOfWork.SaveChangesAsync();

        return BaseResult<object>.Success("Mesaj başarıyla güncellendi ");
    }

}
