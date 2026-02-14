using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Mappings;

public class BlogMappingProfile : Profile
{
    public BlogMappingProfile()
    {
        CreateMap<Blog, GetBlogsQueryResult>().ReverseMap();
        CreateMap<Blog, CreateBlogCommand>().ReverseMap();
        CreateMap<Blog, GetBlogByIdQueryResult>().ReverseMap();
        CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
        CreateMap<Blog, RemoveBlogCommand>().ReverseMap();
        CreateMap<Blog, GetBlogsByCategoryIdQueryResult>().ReverseMap();

    }
}
