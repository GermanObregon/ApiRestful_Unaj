

using Api_Restful.AccesData.Configurations;
using Api_Restful.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Restful.AccesData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
            ) : base(options)
        {

        }

        public DbSet<Mercaderia> Mercaderia { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderia { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new MercaderiaConfigurations(modelBuilder.Entity<Mercaderia>());
            new ComandaConfigurations(modelBuilder.Entity<Comanda>());
            new FormaEntregaConfigurations(modelBuilder.Entity<FormaEntrega>());
            new TipoMercaderiaConfigurations(modelBuilder.Entity<TipoMercaderia>());


            base.OnModelCreating(modelBuilder); 
        }
    }
    
    
}
