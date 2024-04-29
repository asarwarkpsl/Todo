

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                   .Property(b => b.Title)
                   .IsRequired();
            
            modelBuilder.Entity<List>()
                .Property(b=>b.Title)
                .IsRequired();

            //Data Migration
            modelBuilder.Entity<List>()
                .HasData(
                    new List
                     {
                        id = 1,
                        Title = "Lorem ipsum",
                        Timestamp = DateTime.Parse("23/04/2024 14:13"),
                        isEnabled = true 
                     },
                     new List
                     {
                         id = 2,
                         Title = "dolor sit amet",
                         Timestamp = DateTime.Parse("23/04/2024 10:13"),
                         isEnabled = true
                     }
                );

            modelBuilder.Entity<Task>()
                .HasData(
                    new Task
                    {
                        id = 1,
                        ListId = 1,
                        Title= "tincidunt ornare",
                        Description = "viverra tellus in hac habitasse",
                        Status = "Active",
                        DueDate = DateTime.Parse("28/04/2024"),                        
                        Type =  "None",
                        Timestamp = DateTime.Parse("23/04/2024 14:13"),
                        FileURL = "files/Image.png",
                        isEnabled =  true,
                    },
                    new Task
                    {
                        id = 2,
                        ListId = 2,
                        Title = "tincidunt ornare",
                        Description = "viverra tellus in hac habitasse",
                        Status = "Active",
                        DueDate = DateTime.Parse("28/04/2024"),
                        Type = "None",
                        Timestamp = DateTime.Parse("23/04/2024 14:13"),
                        FileURL = "files/Image.png",
                        isEnabled = true,
                    }
                );
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<List> Lists { get; set; }
    }
}