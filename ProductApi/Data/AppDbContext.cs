using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Material> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Material"); 

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(m => m.Material_ID).HasColumnName("Material_ID");
                entity.Property(m => m.Material_Name).HasColumnName("Material_Name");
                entity.Property(m => m.Material_Cost).HasColumnName("Material_Cost");
            });
        }
    }
}