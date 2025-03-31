using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductIllustration> ProductIlustrations { get; set; } // Asegúrate de que el DbSet esté definido correctamente

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo de la tabla y esquema
            modelBuilder.Entity<ProductIllustration>().ToTable("Illustration", "Production");
            modelBuilder.Entity<ProductIllustration>().HasKey(p => p.IllustrationID);
        }
    }
}
