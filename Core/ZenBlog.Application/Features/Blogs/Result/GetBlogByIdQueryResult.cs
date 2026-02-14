using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Result;

public class GetBlogByIdQueryResult : BaseDto
{
    public string Title { get; set; }
    public string CoverImage { get; set; } //kapak resmi
    public string BlogImage { get; set; } //Bloğun içindeki resim
    public string Description { get; set; }//Tanım,Açıklama
    public Guid CategoryId { get; set; }
    public GetCategoryQueryResult Category { get; set; }
    public string UserId { get; set; }
    // public  AppUser User { get; set; }
    //public  IList<Comment> Comments { get; set; }

}
