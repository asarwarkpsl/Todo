using Core.Model;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Infrastructure.Repository
{
    public class ListRepository : IGenericRepository<List>
    {
        public TodoContext _context { get; }

        public ListRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<List> Add(List item)
        {
            var added = await _context.AddAsync(item);            
            await _context.SaveChangesAsync();

            return added.Entity;
        }

        public async Task Delete(List item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List?> Get(int index)
        {
            if (_context != null)
                return await _context.FindAsync<List>(index);
            else
                return null;
        }

        public async Task<IList<List>> GetAll()
        {
            return await _context.Lists.ToListAsync();
        }

        public async Task<List?> Update(List item)
        {
            var listItem = _context.Lists.Find(item.id);
            if (listItem == null)
                return null;

            listItem.isEnabled = item.isEnabled;
            listItem.Title = item.Title;

            await _context.SaveChangesAsync();
            return listItem;
        }
    }
}
