using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    internal class GetCommentsByIdQueryHandler(IRepository<Comment> repository, IMapper mapper) : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                return BaseResult<GetCommentByIdQueryResult>.NotFound("Yorum Bulunamadı");
            }

            var comment = mapper.Map<GetCommentByIdQueryResult>(value);

            return BaseResult<GetCommentByIdQueryResult>.Success(comment);
        }
    }
}
