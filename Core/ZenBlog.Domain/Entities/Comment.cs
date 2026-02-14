
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities;

public class Comment:BaseEntity  //yorum entitysi
{
    public string UserId { get; set; }

    public virtual AppUser  User{ get; set; }//Her commendin bi yazarı var.
    public string Body { get; set; } //yorumun içeriği
    public DateTime CommentDate { get; set; }
    
    public virtual IList<SubComment> SubComments { get; set; } //Birden fazla subcomment olabilir. 


    //Bi,r yorum bir bogta olur. 
    public Guid BlogId { get; set; }
    public virtual Blog Blog { get; set; }


}
