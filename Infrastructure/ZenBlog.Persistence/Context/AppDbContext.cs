using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Persistence.Context;

    //public class AppDbContext : DbContext
    public class AppDbContext: IdentityDbContext<AppUser,AppRole,string>
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<ContactInfo> ContactInfos { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Social> Socials { get; set; }

    }

