using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Result;

public class GetSubCommentsQueryResult:BaseDto
{
    public string UserId { get; set; }
    public GetUsersQueryResult User { get; set; }//Her subcommendin bi yazarı var.
    public string Body { get; set; } //yorumun içeriği
    public DateTime CommentDate { get; set; }
    public Guid CommentId { get; set; }//primary key değerine commenntid
    public GetCommentsQueryResult Comment { get; set; }//bir alt yorum bir üst yorumda olabilir. 
}
