

using Api_Restful.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Restful.AccesData.Configurations
{
    class ComandaConfigurations
    {
        public ComandaConfigurations(EntityTypeBuilder<Comanda> comanda)
        {
            comanda.HasKey(x => x.ComandaId);

            comanda.Property(x => x.Fecha)
                .IsRequired();

            comanda.Property(x => x.PrecioTotal)
                .IsRequired();

            comanda.HasOne<FormaEntrega>(x => x.FormaEntrega)
                .WithMany(g => g.Comandas)
                .HasForeignKey(s => s.FormaEntregaId)
                .IsRequired();
        }
    }
}
