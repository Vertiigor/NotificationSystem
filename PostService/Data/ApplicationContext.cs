using Microsoft.EntityFrameworkCore;
using NotificationSystem.Models;

namespace NotificationSystem.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
