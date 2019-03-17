using Microsoft.EntityFrameworkCore;
using RentFlatApi.Infrastructure.Model;

namespace RentFlatApi.Infrastructure.Context
{
    public class RentContext : DbContext
    {
        public DbSet<Flat> Flats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.RentFlat.db");
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

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