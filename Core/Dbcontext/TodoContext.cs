

using Microsoft.EntityFrameworkCore;
using Core.Model;
using Task = Core.Model.Task;

namespace Infrastructure.DBContext
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Task> Tasks { get; set; }
        DbSet<List> Lists { get; set; }
    }
}