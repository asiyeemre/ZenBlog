using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
namespace ZenBlog.Application.Base;

public class BaseResult<T>
{

    public T? Data { get; set; }

    //IEnumerable<Error>? Errors: IEnumerable, basitçe "Liste" demektir (üzerinde dönülebilir liste). Hata mesajlarını tutar. Neden liste? Çünkü aynı anda hem "Şifre kısa" hem de "Email hatalı" diye birden çok hata olabilir.
    public IEnumerable<Error>? Errors { get; set; }

    [JsonIgnore]
    public bool IsSuccess => Errors == null || !Errors.Any(); // Error nullsa veya içeriisnde hata yoksa (!Errors.Any()) true döndür.

    [JsonIgnore]
    public bool IsFailure => !IsSuccess;//IsSucces true ise yani hata yoksa burası false, hata varsa burası true olur. 

    //Her seferinde newleyerek dönüş tipini olusturmak yerine static metotlar oluştururuz:


    //Başarılı durumda dönüş
    public static BaseResult<T> Success(T data)
    {
        return new BaseResult<T>
        {
            Data = data
        };

    }


    //Hata İçin dönüş 
    public static BaseResult<T> Fail(string error)
    {
        return new BaseResult<T>
        {
            Errors = [new Error { ErrorMessage = error }]
        };
    }


    //içerisine herhangi bir sey göndermezsek hata mesajı : 
    //FAil methodunun overloadı 
    public static BaseResult<T> Fail()
    {
        return new BaseResult<T>
        {
            Errors = [new Error { ErrorMessage = "Beklenmeyen Bir Hata Oluştu" }]
        };
    }


    public static BaseResult<T> Fail(IEnumerable<IdentityError> errors)
    {
        return new BaseResult<T>
        {
            Errors = (from error in errors
                      select new Error { PropertyName=error.Code,ErrorMessage=error.Description})
        };
    }


    //Liste olarak hata mesajı alma 
    public static BaseResult<T> Fail(IEnumerable<string> errors)
    {
        return new BaseResult<T>
        {
            Errors = (from error in errors
                      select new Error { ErrorMessage = error })
        };
    }

    // Bulunamadı hatası
    public static BaseResult<T> NotFound(string message)
    {
        return new BaseResult<T>
        {
            Errors = [new Error { ErrorMessage = message }]
        };
    }

}

    public class Error
    {
        public string? PropertyName { get; set; }
        public string ErrorMessage { get; set; }

    } 

