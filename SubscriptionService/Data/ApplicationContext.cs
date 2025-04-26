using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubscriptionService.Models;

namespace SubscriptionService.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Channel> Channels { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Subscriptions)
                .WithMany()
                .UsingEntity(j => j.ToTable("UserSubscriptions"));
        }
    }
}
