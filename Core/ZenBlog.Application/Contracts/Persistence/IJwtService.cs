using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Contracts.Persistence;

public interface IJwtService
{
    //Burda tek bir method tanımlayacağız. Token oluşturma methodu.Bunu direkt olarak string olarak döndürebiliriz ama daha sonra tokenın süresi gibi ek bilgiler eklemek isteyebiliriz.Bu yüzden bir sınıf oluşturup onu döndürelim.
    //Users sınıfına Result klasöründe GetLoginResponse.cs adında bir sınıf oluşturduk.


    // buraya bir user parametresi göndermeliyiz. Çünkü token oluştururken kullanıcının bilgilerine ihtiyacımız var.Bunun için içine GetUsersQueryResult tipinde bir user parametresi alacak şekilde methodumuzu tanımlayalım.
    Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result);
}
