using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Commands;

public class UpdateBlogCommand:IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string CoverImage { get; set; } //kapak resmi

    public string BlogImage { get; set; } //Bloğun içindeki resim

    public string Description { get; set; }//Tanım,Açıklama

    public Guid CategoryId { get; set; }


    //Her bir bloğun bir yazarı , kullanıcısı olması lazım . 
    public string UserId { get; set; }
}
