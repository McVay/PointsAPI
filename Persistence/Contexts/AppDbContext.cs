using Microsoft.EntityFrameworkCore;
using PointsAPI.Domain.Models;

namespace PointsAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Point> Point { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.Id);
                user.Property(u => u.Name);
                user.Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
                user.HasMany(u => u.Points).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<Point>(point =>
            {
                point.HasKey(p => p.Id);
                point.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
                point.Property(p => p.PayerName);
                point.Property(p => p.Amount);
                point.Property(p => p.TransactionDate);
            });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Dylan" });
        }
    }
}