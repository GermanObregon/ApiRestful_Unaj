

using Api_Restful.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Restful.AccesData.Configurations
{
    public class ComandaMercaderiaConfigurations
    {
        public ComandaMercaderiaConfigurations(EntityTypeBuilder<ComandaMercaderia> ComandaMercaderia )
        {
            ComandaMercaderia.HasKey(x => x.ComandaId);

            ComandaMercaderia.HasOne<Mercaderia>(x => x.Mercaderia)
                .WithMany(s => s.ComandaMercaderia)
                .HasForeignKey(g => g.Mercaderia)
                .IsRequired();

            ComandaMercaderia.HasOne<Comanda>(x => x.Comanda)
                .WithMany(g => g.ComandasMercaderias)
                .HasForeignKey(S => S.Comanda)
                .IsRequired();
                

        }
    }
}
