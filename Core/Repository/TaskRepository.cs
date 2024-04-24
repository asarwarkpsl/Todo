using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Task = Core.Model.Task;

namespace Infrastructure.Repository
{
    public class TaskRepository : IGenericRepository<Task>
    {
        public TodoContext _context { get; }

        public TaskRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<Task> Add(Task item)
        {
            var added = await _context.AddAsync(item);
            await _context.SaveChangesAsync();

            return added.Entity;
        }

        public async System.Threading.Tasks.Task Delete(Task item)
        {
           _context.Remove(item);
           await _context.SaveChangesAsync();
        }

        public async Task<Task?> Get(int index)
        {
            if (_context != null)
                return await _context.FindAsync<Task>(index);
            else
                return null;
        }

        public async Task<IList<Task>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Task?> Update(Task item)
        {
            var listItem = _context.Tasks.Find(item.id);
            if (listItem == null)
                return null;

            listItem.isEnabled = item.isEnabled;
            listItem.Title = item.Title;

            await _context.SaveChangesAsync();
            return listItem;
        }
    }
}
