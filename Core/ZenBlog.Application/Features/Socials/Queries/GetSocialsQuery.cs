using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Socials.Result;

namespace ZenBlog.Application.Features.Socials.Queries;

public record GetSocialsQuery : IRequest<BaseResult<List<GetSocialsQueryResult>>>;

