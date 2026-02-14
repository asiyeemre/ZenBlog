using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers;

internal class GetSubCommentByIdQueryHandler(IRepository<SubComment> repository, IMapper mapper) : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResult>>
{
    public async Task<BaseResult<GetSubCommentByIdQueryResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var value=await repository.GetByIdAsync(request.Id);
        if (value == null)
        {
            return BaseResult<GetSubCommentByIdQueryResult>.NotFound("Yorum Bulunamadı");
        }


        var response=mapper.Map<GetSubCommentByIdQueryResult>(value);

        return BaseResult<GetSubCommentByIdQueryResult>.Success(response);


    }
}
