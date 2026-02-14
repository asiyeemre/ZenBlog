using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities;

    public class Blog:BaseEntity
    {
    // " BaseEntity" diyerek miras aldık. 
    // Artık Blog sınıfının da gizli bir Id ve CreatedDate'i var

    public string  Title { get; set; }
    public string CoverImage { get; set; } //kapak resmi

    public string BlogImage { get; set; } //Bloğun içindeki resim

    public string Description { get; set; }//Tanım,Açıklama

    public Guid CategoryId { get; set; }

    public virtual  Category Category { get; set; } //Bire çok ilişki .Bir blog 1 kategoride olabilir. 



    //Her bir bloğun bir yazarı , kullanıcısı olması lazım . 
    public string UserId { get; set; }
    public virtual  AppUser User { get; set; }

    //Bir blogta nbirden fazla comment olabilir
    public virtual IList<Comment> Comments { get; set; }


}
//Blogları listelersek içerisinden tüm yorumlara ulaşcaz. yorumlara ulaşınca da  her yorumun içinden alt yorumlara ulaşcaz 

