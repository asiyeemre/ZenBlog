

namespace ZenBlog.Application.Contracts.Persistence;


/// <summary>
/// Unit of Work Deseni: Veritabanı işlemlerini tek bir merkezden yöneten "Patron" yapıdır.
/// <para>
/// <b>Ne İşe Yarar?</b>
/// <br/>1. <b>Transaction Yönetimi (Ya Hep Ya Hiç):</b> Yapılan birden fazla değişikliğin (Ekleme, Silme, Güncelleme) aynı anda veritabanına yansımasını sağlar. İşlemlerden biri bile hata verirse, hiçbiri kaydedilmez (Rollback). Veri tutarlılığını korur.
/// <br/>2. <b>Performans:</b> Veritabanına her işlem için ayrı ayrı gitmek yerine, tüm değişiklikleri hafızada (RAM) biriktirir ve tek seferde toplu olarak veritabanına gönderir.
/// </para>
/// </summary>
public interface IUnitOfWork
    {
    /// <summary>
    /// Hafızada bekleyen (Repository'ler tarafından eklenen/güncellenen) tüm işlemleri veritabanına kalıcı olarak kaydeder (Commit).
    /// </summary>
    /// <returns>Etkilenen satır sayısını döner.</returns>
    Task <bool >SaveChangesAsync();

    //UnitOfWork kullandık çünkü repository katmanında tek tek savechanges yazmak yerine direkt bunu merkezileştirdik.  Aynı zamanda transaction işlemine de yardımcı olur unitofwork.
    }

