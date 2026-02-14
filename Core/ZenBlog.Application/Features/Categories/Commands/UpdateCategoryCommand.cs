using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands;



/*UpdateCategoryCommand = ne yapılacağını söyleyen mesaj. Bu mesaj olmasa:

-Handler neyi değiştirecek?
-Hangi id’nin güncelleneceğini nereden bilecek?
-Yeni category name nereden gelecek?
-Bizim isteğimiz hangi işlem için? Delete mi? Update mi? Create mi?
Handler ortalıkta boş boş bakardı.

Görevi veriyi taşımak + niyeti belirtmek.

->Görev tanımını yapan = UpdateCategoryCommand
->Görevi yapan kişi = UpdateCategoryHandler

**init, property’yi yalnızca nesne oluşturulurken set edebilirsin demektir.*/
public record UpdateCategoryCommand(Guid Id, string CategoryName) : IRequest<BaseResult<bool>>;


// * Record = veri taşıyan nesne
//* Class = davranış + veri içeren nesne

/*UpdateCategoryCommand içinde hiç davranış (metod) yok.Sadece API’den gelen veriyi handler’a taşımak istiyoruz.Yani: Id ve CategoryName.
Bu bir “data object”.
O yüzden: Record daha mantıklı
 “record” tam olarak ne sağlar?
 1) Otomatik immutability : Veri taşınıyor → değiştirilmeyecek → cuk oturuyor.
 2) Otomatik eşitlik karşılaştırması : İki record içeriği aynıysa eşit sayılıyor.
 3) Constructor kendiliğinden oluşuyor: new UpdateCategoryCommand(id, "Backend");
 4) Çok daha küçük yazım: Class yazsan şuna dönerdi:

public class UpdateCategoryCommand : IRequest<BaseResult<bool>>
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }

    public UpdateCategoryCommand(Guid id, string categoryName)
    {
        Id = id;
        CategoryName = categoryName;
    }
} 

 --------------------------------------------------------------------------------------------------------------------------
IRequest hiçbir şey yapmıyor.IRequest’in içinde hiçbir metod yok.Aynı şunun gibi => public interface IRequest<TResponse> { }
BOŞ.Yani:
davranış yok
logic yok
metot yok
property yok
Sadece bir işaretçi.

****Peki o zaman ne işe yarıyor?****
IRequest sayesinde MediatR otomatik olarak diyor ki:
“Bunu işleyebilecek handler’ı bulayım.”
Mesela:

public record UpdateCategoryCommand(Guid Id, string CategoryName)
    : IRequest<BaseResult<bool>>;


Bu command’i MediatR şöyle okur:

→ “Tamam bu bir IRequest”
→ “Bunun cevabı BaseResult<bool> olacakmış.”
→ “O zaman kim bu tipte Handle yazmış, ona göndereyim.”

Bulduğu handler:

public class UpdateCategoryHandler 
    : IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
{
    public Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken token)
    {
        ...
    }
}


MediatR bu iki parçayı IRequest üzerinden birleştirir.
IRequest → “Benim handler’ımı bul.”

IRequestHandler → “Ben şu REQUEST’i işliyorum.”

MediatR → “Tamam lan siz eşleşiyorsunuz.”*/

