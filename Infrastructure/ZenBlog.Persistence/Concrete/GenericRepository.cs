
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities.Common;
using ZenBlog.Persistence.Context;

namespace ZenBlog.Persistence.Concrete;

    public class GenericRepository<TEntity> (AppDbContext _context): IRepository<TEntity> where TEntity : BaseEntity
    {
    //Eski usuülde dışardan bir Dbcontext almak için sınıfın içine contructor yazılır. asağıdaki gibi :
    //private readonly AppDbContext _context;
    //public GenericRepository(AppDbContext context)
    //{
    //    _context = context; 

    //}
    // ama şimdi c# 12 nin getirdiği yenilikle (Primary Constructor) Sınıf adının hemen yanına AppDbContext _context yazarak c#
    // arka planda o değişkeni senin için olusturuyor ve atamasını yapıyor.

    private readonly DbSet<TEntity> _table = _context.Set<TEntity>();

    // burada gelecek olan sınıfın (generic sayesinde gelen entity sınıfı TEntitye yerlesir .)  tablosunu entityframewrok bize verştabanından
    // getiriyor ve biz de onu _table değişkenşne atıyoruz.
    //bu sayede gelmesi gereken tablo değiştirğinde zorlanmıcaz tek tek kod yazmıcaz. ve crud işlemleri için uzun kodlar yazmıcaz .
    //_table. dicez sadece._context.Set<TEntity>().Add(...) yazmıcaz 

        public async Task CreateAsync(TEntity entity)
        {
                await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
          return await _table.AsNoTracking().ToListAsync(); // performansı arttırmak için AsNoTracking ekledik çünkü egrek yok tüm tabloyu listelerken . 

    }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {

        return await _table.FindAsync(id);
        }

        public IQueryable<TEntity> GetQuery()
        {
        return _table;
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
        return await _table.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);    
        }
    }

