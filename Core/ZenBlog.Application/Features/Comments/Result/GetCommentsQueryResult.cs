using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Result;

public class GetCommentsQueryResult:BaseDto
{
    public string UserId { get; set; }

    public virtual GetUsersQueryResult User { get; set; }//Her commendin bi yazarı var.
    public string Body { get; set; } //yorumun içeriği
    public DateTime CommentDate { get; set; }

    //public virtual IList<SubComment> SubComments { get; set; } //Birden fazla subcomment olabilir. 


    //Bi,r yorum bir bogta olur. 
    public Guid BlogId { get; set; }
    public  GetBlogByIdQueryResult Blog { get; set; }

}
