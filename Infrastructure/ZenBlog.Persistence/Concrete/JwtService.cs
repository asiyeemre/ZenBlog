using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ZenBlog.Persistence.Concrete;

public class JwtService(UserManager<AppUser> userManager, IOptions<JwtTokenOptions> tokenOptions) : IJwtService
{
    private readonly JwtTokenOptions _jwtTokenOptions = tokenOptions.Value; //IOptions dan gelen değeri alıyoruz.alcağımız değerler : Key, Issuer, Audience, ExpirationInMinutes
    public async  Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result)
    {
        var user = await userManager.FindByNameAsync(result.UserName);
        //burda bu işlemi yapmamızın sebebi, user parametresinde sadece GetUsersQueryResult tipinde bilgiler var. Ama biz token oluştururken AppUser tipinde bilgilere ihtiyacımız var. O yüzden usermanager ile kullanıcıyı bulup AppUser tipinde bilgileri alıyoruz.
        //Yani user parametresinde sadece kullanıcı adı, email gibi bilgiler var ama biz token oluştururken kullanıcı idsi gibi bilgilere de ihtiyacımız var. O yüzden usermanager ile kullanıcıyı bulup AppUser tipinde bilgileri alıyoruz.

        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key)); 
        //simetrik anahtar olusturduk. Bu anahtar tokenin imzalanmasında kullanılacak.
        //simetrik anahtar: aynı anahtar hem imzalamada hem de doğrulamada kullanılır.
        //yani mesela bu anahtarla token oluşturulursa, aynı anahtarla token doğrulanabilir.

        var dateTimeNow= DateTime.UtcNow; //şuanki zamanı aldık. tokenın oluşturulma zamanı olarak kullanacağız.

        List<Claim> claims = new() //tokenın içinde yer alacak bilgiler.
        {
            new (JwtRegisteredClaimNames.Name,user.UserName),//JwtRegisteredClaimNAmes : token içinde kullanılabilecek standart claim isimlerini tutar.
            new (JwtRegisteredClaimNames.Sub,user.Id),//sub: subject, yani tokenın konusu. genellikle kullanıcı idsi olur.
            new (JwtRegisteredClaimNames.Email,user.Email),//
            new ("fullName",string.Join("",user.FirstName,user.LastName)), 
            // burda jwtregisteredclaimnames kullanmadık çünkü fullname diye bir standart claim ismi yok.FirstName ve LastName i birleştirip fullName claimini oluşturduk.Buna custom claim denir.
        };
        JwtSecurityToken jwtSecurityToken = new( //burda token oluşturuluyor.
            issuer: _jwtTokenOptions.Issuer, //tokenı oluşturan
            audience: _jwtTokenOptions.Audience, //tokenı kullanan
            claims: claims,//tokenın içinde yer alacak bilgiler
            notBefore: dateTimeNow,//tokenın geçerli olmaya başlayacağı zaman
            expires: dateTimeNow.AddMinutes(_jwtTokenOptions.ExpirationInMinutes), //tokenın geçerlilik süresi
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256) //tokenın imzalanmasında kullanılacak bilgiler
            );
        GetLoginQueryResult response = new(); //dönen response objesi

        response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);//token string olarak oluşturuluyor.
        response.ExpirationTime = dateTimeNow.AddMinutes(_jwtTokenOptions.ExpirationInMinutes);//tokenın geçerlilik süresi

        return response;
    


        
    }
}
