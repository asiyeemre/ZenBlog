using ZenBlog.Domain.Entities.Common;
namespace ZenBlog.Domain.Entities;

public class SubComment:BaseEntity  //yorumların altındaki cevaplar 
{
    public string UserId { get; set; }
    public virtual AppUser User { get; set; }//Her subcommendin bi yazarı var.
    public string Body { get; set; } //yorumun içeriği
    public DateTime CommentDate { get; set; }

    public Guid  CommentId { get; set; }//primary key değerine commenntid
    public virtual Comment Comment { get; set; }//bir alt yorum bir üst yorumda olabilir. 
}
