using System.Linq.Expressions;
using ZenBlog.Domain.Entities;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Application.Contracts.Persistence;
/// <summary>
/// Bu bir Generic Repositorydir. Buradaki TEntity bir yer tutucudur(Matematikteki x gibi).
///Sen bu depoyu kullanırken TEntity yerine Blog yazarsan kod Blog için çalışır, Category yazarsan Category için çalışır.
///where TEntity : BaseEntity ==> Bu bir güvenlik önlemidir.Yani TEntity yerine her şeyi yazamazsın. Yazacağın sınıf
///MUTLAKA BaseEntity sınıfından türetilmiş bir veritabanı nesnesi olmalıdır.(Böylece yanlışlıkla IRepository<string> gibi saçma bir şey yazmanı engeller).
/// </summary>

    public interface IRepository<TEntity> where TEntity:BaseEntity

{
    /// <summary>
    /// List<TEntity>: Veritabanındaki tablonun tamamını bir liste olarak getirir. (Select * from Blogs gibi).
    /// Task: Bu işlemin Asenkron olduğunu gösterir. Yani veritabanından 1000 tane blog gelirken uygulaman donmaz. Arka planda çalışır, bitince sonucu döner.
    /// </summary>
    /// <returns></returns>
    Task<List<TEntity>> GetAllAsync();
    
    IQueryable<TEntity> GetQuery();
    // Veriyi hemen çekmez! Sadece sorguyu hazırlar.
    // Bunun üzerine .Where(), .OrderBy() gibi filtreler ekleyip en son veriyi çekebilirsin.
    // Esnek sorgulama yapmak için kullanılır.
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
    //Filtrelemeye yarar.
    // Özel bir şarta göre tek bir kayıt getirir.
    // Örn: GetSingleAsync(x => x.Baslik == "Spor Haberleri") diyebilirsin.
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    }

