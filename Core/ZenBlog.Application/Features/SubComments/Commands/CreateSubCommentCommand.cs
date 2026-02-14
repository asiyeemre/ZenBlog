using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands;

public record CreateSubCommentCommand:IRequest<BaseResult<object>>
{
    public string UserId { get; init; }
    public string Body { get; init; } //yorumun içeriği
    [JsonIgnore]
    public DateTime CommentDate { get; init; }= DateTime.Now;
    public Guid CommentId { get; init; }//primary key değerine commenntid
}
