using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Command;

public record UpdateSocialCommand(Guid Id,string Title,string Url,string Icon):IRequest<BaseResult<object>>;

    //public Guid Id { get; init; }

    //public string Title { get; init; }
    //public string Url { get; init; }
    //public string Icon { get; init; }


