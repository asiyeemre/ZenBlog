using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Persistence.Interceptors;

//SaveChangesInterceptor EF Core’un sunduğu bir extension point — DBContext çağrıları sırasında müdahale etmeni sağlar.
//SavingChangesAsync override edilerek, EF veritabanına kaydetmeden önce işlem yapılabiliyor.
public class AuditDbContextInterceptor : SaveChangesInterceptor

{

    //Key → Value çiftlerini saklayan bir koleksiyon.
    //Key(anahtar) : Tekil olmak zorunda.
    //Value(değer): Key’e karşılık gelen veri.
    private static readonly Dictionary<EntityState, Action<DbContext, BaseEntity>> Behaviors = new()
    {
        {
            EntityState.Added ,AddedBehavior //Durum ekleme ise Added Behavior fonksiyonu  çalışsın
        },
        {
            EntityState.Modified ,ModifiedBehavior //Durum güncelleme ise modifiedBehavior çalışsın 
        }
    };

    private static void AddedBehavior(DbContext context,BaseEntity baseEntity)
    {
        context.Entry(baseEntity).Property(x => x.UpdatedAt).IsModified = false;  //EF e , Added sırasında UpdatedAt ile uğraşma.Bu sadece update’te değişsin diyoruz.Veritabnında update güncellenmiyor.
        baseEntity.CreatedAt=DateTime.Now;

    }
    private static void ModifiedBehavior(DbContext context,BaseEntity baseEntity)
    {
        context.Entry(baseEntity).Property(x => x.CreatedAt).IsModified = false;
        baseEntity.UpdatedAt=DateTime.Now;

    }

    //EF Core tam “SaveChanges” atacağı anda bu metot devreye giriyor.
    //INSERT atılmadan önce UPDATE atılmadan önce
   //Bu interceptor araya giriyor ve “dur, önce ben bi bakayım” diyor.
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
    {

        /*ChangeTracker → EF’nin tuttuğu bütün değişiklik yapan entity’ler.
          Entries() → o an eklenen, güncellenen, silinen her entity’nin bilgisi.
        Biz bunlar üzerinde tek tek dolaşıyoruz:*/
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            /*Her entry şunu içerir:
            Entity → gerçek nesne - State → Added / Modified / Deleted / Unchanged - Properties → kolonlar - OriginalValues - CurrentValues*/
            if (entry.Entity is not BaseEntity baseEntity)
            {
                continue;
                //Bu entity Base Entity türünde değilse bunu geç diğerine bak 
            }
            if(entry.State is not EntityState.Added and not EntityState.Modified )
            { 
                continue;
                // bu entitiynin statei added veya modified değilse geç sıradakine . 
            }

            Behaviors[entry.State](eventData.Context, baseEntity);
            //entry durumu neyse o fonksiyona git içine context ve base entity alarak o verilerle 
        }


        return base.SavingChangesAsync(eventData, result, cancellationToken);
        //Bu satırdan sonra biz işlemlerimizi bitirmiş oldugumuz işçin efcore kendi işlemleini yapmaya devam eder. 
    }
}
