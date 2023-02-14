using Backend.Contracts;
using Backend.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Backend.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly CustomerDBContext _context;
        public RepositoryBase(CustomerDBContext context)
        {
            this._context = context;

        }

        public CustomerDBContext GetContext()
        {
            return this._context;
        }
        public async Task BulkAdd(List<T> listData) {

            foreach (var item in listData)
            {
                Add(item);
            }
            await SaveChangesAsync();
        }

        public T Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public async Task<T> Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public  T Edit(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
            return obj;
        }
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await this._context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._context.Set<T>().AsNoTracking().ToListAsync();

        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
