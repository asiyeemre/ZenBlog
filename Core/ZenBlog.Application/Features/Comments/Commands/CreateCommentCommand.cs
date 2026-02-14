using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Commands;

public record CreateCommentCommand:IRequest<BaseResult<object>>
{
    public string UserId { get; init; }

    public string Body { get; init; } //yorumun içeriği

    [JsonIgnore]
    public DateTime CommentDate { get; init; }=DateTime.Now;
    public Guid BlogId { get; init; }

}
