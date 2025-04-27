using Microsoft.EntityFrameworkCore;
using PostService.Models;

namespace PostService.Data
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
