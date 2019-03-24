using Microsoft.EntityFrameworkCore;
using RentFlatApi.Infrastructure.Model;

namespace RentFlatApi.Infrastructure.Context
{
    public class RentContext : DbContext
    {
        public DbSet<Flat> Flat { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Image> Image { get; set; }

        public RentContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.RentFlatApi.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flat>()
                .HasMany(x => x.Images)
                .WithOne(y => y.Flat)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}