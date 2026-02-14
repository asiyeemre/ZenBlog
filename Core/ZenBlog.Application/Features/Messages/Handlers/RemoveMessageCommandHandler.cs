using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers;

public class RemoveMessageCommandHandler(IRepository<Message> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveMessageCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await repository.GetByIdAsync(request.Id);
        if (message == null)
        {
            return BaseResult<object>.Fail("Mesaj bulunamadı");
        }
        repository.Delete(message);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Mesaj başarıyla silindi");
    }

}
