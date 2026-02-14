namespace ZenBlog.Application.Options;

public class JwtTokenOptions
{
    public string Issuer { get; set; } //Tokenı oluşturan, yayınlayan.7000 portu. api.zenblog.com
    public string Audience { get; set; }//Tokenı kullanan, hedef kitle.Dinleyen taraf.4200 portyndan.www.zenblog.com
    public string Key { get; set; } //Tokenın imzalanmasında kullanılan gizli anahtar.
    public int ExpirationInMinutes { get; set; }//Tokenın geçerlilik süresi.dakika cinsinden.
}
