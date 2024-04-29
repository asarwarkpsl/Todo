using Core.Model;
using Core.Specification;
using Infrastructure.Data;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        public TodoContext _context { get; }

        public GenericRepository(TodoContext context)
        {
            _context = context;
        }


        public async Task<T> Add(T item)
        {
            var added = await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();

            return added.Entity;
        }

        public async Task Delete(T item)
        {
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> Get(int id)
        {
            if (_context != null)
                return await _context.Set<T>().FindAsync(id);
            else
                return null;
        }

        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }       

        public async Task<T?> Update(T item)
        {
            var listItem = _context.Set<T>().Find(item.id);
            if (listItem == null)
                return null;

            listItem.Title = item.Title;

            await _context.SaveChangesAsync();
            return listItem;
        }

        public async Task<T?> GetEnityWithSpec(ISpecification<T> specification)
        {
            var entity = await ApplySpecification(specification).FirstOrDefaultAsync<T>();
            if (entity == null)
                return null;

            return entity;
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
