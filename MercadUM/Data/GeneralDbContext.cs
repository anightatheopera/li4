using MercadUM.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MercadUM.Data
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public GeneralDbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.Entity<ApplicationBarraca>(entity =>
            {
                entity.ToTable(name: "barracas");
            });
            builder.Entity<ApplicationFeira>(entity =>
            {
                entity.ToTable(name: "feiras");
            });
            builder.Entity<ApplicationProduto>(entity =>
            {
                entity.ToTable(name: "produtos");
            });
        }

        public DbSet<ApplicationBarraca> Barracas { get; set; }
        public DbSet<ApplicationFeira> Feiras { get; set; }
        public DbSet<ApplicationProduto> Produtos { get; set; }

    }  
}
