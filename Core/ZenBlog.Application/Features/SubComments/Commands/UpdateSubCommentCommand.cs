using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands;

public record UpdateSubCommentCommand:IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string UserId { get; init; }
    public string Body { get; init; } //yorumun içeriği
    public Guid CommentId { get; init; }//primary key değerine commenntid

}
