using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers;

public class UpdateSubCommentCommandHandler(IRepository<SubComment> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateSubCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateSubCommentCommand request, CancellationToken cancellationToken)
    {
        var subComment = await repository.GetByIdAsync(request.Id);
        if (subComment == null)
        {
            return BaseResult<object>.Fail("Yorum bulunamadı.");
        }
        // Güncellenebilir alanları ayarla
        subComment = mapper.Map(request, subComment);

        repository.Update(subComment);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("yorum güncellendi");

    }
}
