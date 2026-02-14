using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entities;
using ZenBlog.Persistence.Concrete;
using ZenBlog.Persistence.Context;
using ZenBlog.Persistence.Interceptors;

namespace ZenBlog.Persistence.Extensions;

    public static  class ServiceRegistrations
    {
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(name: "SqlConnection"));
            options.AddInterceptors(new AuditDbContextInterceptor());
            options.UseLazyLoadingProxies();
        });

        services.AddIdentity<AppUser, AppRole>(options =>
        { 
        options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<IUnitOfWork,UnitOfWork>();
        //"Eğer biri senden IUnitOfWork (Patron) isterse, ona UnitOfWork (Gerçek Patron) sınıfını ver."

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        //"Ey Uygulama! Eğer birisi senden IRepository<HerhangiBirŞey> isterse (Blog olur, Kategori olur fark etmez),
        //sen git otomatik olarak ona uygun GenericRepository<O_Şey> üret ve ver."
        //typeof -> C#'ta sınıfın kendisini (tipini) belirtmek için kullanılır.
        //<> (İçi boş) -> "İçine ne geleceği belli değil, her şey gelebilir" demektir.

        services.AddScoped<IJwtService, JwtService>();  //"Eğer biri senden IJwtService isterse, ona JwtService sınıfını ver."

        services.AddAuthentication(options =>   //JWT ile kimlik doğrulama yapacağımızı belirtiyoruz
        {
            options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme; //bu yapı şu anlama gelir: "Varsayılan olarak, kimlik doğrulama işlemi için JWT Bearer şemasını kullan."
            options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme; //bu yapı şu anlama gelir: "Varsayılan olarak, kimlik doğrulama zorluğu (challenge) için JWT Bearer şemasını kullan."

        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt => //bu yapılandırma JWT Bearer şeması için özel ayarları belirtir.
        {
            var jwtTokenOptions= configuration.GetSection(nameof(JwtTokenOptions)).Get<JwtTokenOptions>();
            // bu satır, uygulamanın yapılandırma dosyasından (örneğin app settings.json) "JwtTokenOptions" adlı bölümü alır ve bu bölümdeki ayarları JwtTokenOptions sınıfına dönüştürür.Yani detaylandırmak gerekirse : configuration.GetSection(nameof(JwtTokenOptions)) kısmı, yapılandırma dosyasındaki "Jwt TokenOptions" adlı bölümü alır. .Get<JwtTokenOptions>() kısmı ise bu bölümdeki ayarları JwtTokenOptions türüne dönüştürür ve jwtTokenOptions değişkenine atar.
            //bunu yaptık çünkü token doğrulama için gerekli ayarları (issuer, audience, key vb.) bu sınıfta tutuyoruz.
       
            // şimdi bu ayarları kullanarak token doğrulama parametrelerini belirleyeceğiz.
            opt.TokenValidationParameters = new() // bu yapı şu anlama gelir: "Token doğrulama parametrelerini yeni bir TokenValidationParameters nesnesi ile belirle."
            {

                ValidateIssuer = true, // yani bu şu demek : "Token üzerindeki issuer (yayımlayan) bilgisini doğrula."
                ValidateAudience = true, // aliidateAudience = true demek : "Token üzerindeki audience (hedef kitle) bilgisini doğrula."
                ValidateLifetime = true, // yani bu demek : "Token'ın süresinin dolup dolmadığını doğrula."
                ValidateIssuerSigningKey = true, // bu yapı şu demek: "Token'ın imza anahtarını doğrula."
                ValidIssuer = jwtTokenOptions.Issuer,// bu yapı şu demek: "Geçerli issuer (yayımlayan) bilgisi jwtTokenOptions içindeki Issuer değeridir."
                ValidAudience = jwtTokenOptions.Audience, // bu yapı şu demek: "Geçerli audience (hedef kitle) bilgisi jwtTokenOptions içindeki Audience değeridir."
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenOptions.Key)), // bu yapı şu demek: "Token'ın imza anahtarı, jwtTokenOptions içindeki Key değerinden oluşturulan simetrik bir güvenlik anahtarıdır." utf8 ile byte dizisine çeviriyoruz.çümkü securitykey byte dizisi ister. byte dizisi demek 0 ve 1 lerden oluşan dizi demek.utf 8 ise karakterleri bilgisayarın anlayacağı 0 ve 1 lere çevirme standardıdır.
                ClockSkew = TimeSpan.Zero, // bu yapı şu demek: "Token'ın süresi dolduktan sonra kabul edilebilir ek süre sıfırdır." Yani token tam süresi dolduğunda geçersiz sayılacak, ekstra bir tolerans süresi verilmeyecek.
            };
        });



    }


}

