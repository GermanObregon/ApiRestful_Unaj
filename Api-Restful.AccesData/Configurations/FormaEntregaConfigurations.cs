using Api_Restful.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Restful.AccesData.Configurations
{
    class FormaEntregaConfigurations
    {
        public FormaEntregaConfigurations(EntityTypeBuilder<FormaEntrega> FormaEntrega)
        {
            FormaEntrega.HasKey(x => x.FormaEntregaId);
            
            FormaEntrega.Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(50);

            FormaEntrega.HasData(new FormaEntrega { FormaEntregaId = 1, Descripcion = "Salon" });
            FormaEntrega.HasData(new FormaEntrega { FormaEntregaId = 2, Descripcion = "Delivery" });
            FormaEntrega.HasData(new FormaEntrega { FormaEntregaId = 3, Descripcion = "Pedidos Ya" });

        }
    }
}
