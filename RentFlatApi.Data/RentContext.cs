using System.Reflection;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using RentFlatApi.Data.Model;

namespace RentFlatApi.Data
{
    public class RentContext : DbContext
    {
        public DbSet<Flat> Flats { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.RentFlat.db");
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