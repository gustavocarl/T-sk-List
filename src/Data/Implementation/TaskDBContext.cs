using Microsoft.EntityFrameworkCore;
using Task_List.Models;

namespace Task_List.Data.Implementation
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(k => k.Id);
            });
        }
    }
}