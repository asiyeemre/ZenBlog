using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands;

public class UpdateCommentCommand:IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string UserId { get; init; }
    public string Body { get; init; } //yorumun içeriği
    public Guid BlogId { get; init; }
}
