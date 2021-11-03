

using Api_Restful.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Restful.AccesData.Configurations
{
    public class TipoMercaderiaConfigurations
    {
        public TipoMercaderiaConfigurations(EntityTypeBuilder<TipoMercaderia> TipoMercaderia)
        {
            TipoMercaderia.HasKey(x => x.TipoMercaderiaId);

            TipoMercaderia.Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(50);

            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 1, Descripcion = "Entrada" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 2, Descripcion = "Minutas" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 3, Descripcion = "Pastas" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 4, Descripcion = "Parrilla" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 5, Descripcion = "Pizzas" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 6, Descripcion = "Sandwich" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 7, Descripcion = "Ensaladas" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 8, Descripcion = "Bebidas" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 9, Descripcion = "Cervezas Artesanales" });
            TipoMercaderia.HasData(new TipoMercaderia { TipoMercaderiaId = 10, Descripcion = "Postres" });
        }
    }
}
