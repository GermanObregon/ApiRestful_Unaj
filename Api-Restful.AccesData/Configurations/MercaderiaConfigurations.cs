


using Api_Restful.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Restful.AccesData.Configurations
{
    class MercaderiaConfigurations 
    {
        public MercaderiaConfigurations(EntityTypeBuilder<Mercaderia> Mercaderia)
        {
            Mercaderia.HasKey(x => x.MercaderiaId);

            Mercaderia.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            
            Mercaderia.Property(x => x.Precio)
                .IsRequired();

            Mercaderia.Property(x => x.Ingredientes)
                .IsRequired()
                .HasMaxLength(255);

            Mercaderia.Property(x => x.Imagen)
                .IsRequired()
                .HasMaxLength(255);

            Mercaderia.Property(x => x.Preparacion)
                .IsRequired()
                .HasMaxLength(255);

            Mercaderia.HasOne<TipoMercaderia>(s => s.TipoMercaderia)
                .WithMany(g => g.Mercaderias)
                .HasForeignKey(x => x.TipoMercaderiaId)
                .IsRequired();
            
            Mercaderia.HasData(new Mercaderia { MercaderiaId = 1, Nombre = "Ceviche Cremoso" ,Precio = 250, TipoMercaderiaId = 1 , Ingredientes = "dados de salmón marinados en jugo de lima, crema de ají amarillo, chips y maíz frito",
                                Preparacion = "Un plató típico de la gastronomía peruana" , Imagen = "http://malevamag.com/wp-content/uploads/2017/11/Ceviche-cremosos-Puerta-del-Inca-1200x800.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 2,
                Nombre = "Gramajo",
                Precio = 195,
                TipoMercaderiaId = 1,
                Ingredientes = "Jamón marinado y glaseado a la parrilla, huevo a baja temperatura con polvo de aceitunas negras, salteado de arvejas, cebolla encurtida y papas fritas a la provenzal.",
                Preparacion = "Una receta que data de la época de la gran inmigración europea a la Argentina y que constituye un clásico de nuestra gastronomía.",
                Imagen = "http://malevamag.com/wp-content/uploads/2017/11/Inmigrante_12__rp-1200x800.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 3,
                Nombre = "Empanadas de Ciervo",
                Precio = 195,
                TipoMercaderiaId = 1,
                Ingredientes = "La masa es casera y el relleno se prepara con carne de ciervo que fue braseado por muchas horas.",
                Preparacion = "Se sirve con una fresca ensalada de rabanitos y verdes, más una salsa de tomates con limón que potencia todos los sabores.",
                Imagen = "http://malevamag.com/wp-content/uploads/2017/11/Empanada-de-Ciervo-Alos-1198x800.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 4,
                Nombre = "Pizza Frita Margherita",
                Precio = 140,
                TipoMercaderiaId = 1,
                Ingredientes = "Sale con mozzarella, tomate y albahaca fresca",
                Preparacion = "Un plato típico de la cocina callejera napolitana.",
                Imagen = "http://malevamag.com/wp-content/uploads/2017/11/Pizza-Frita-Ike-Milano-1200x800.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 5,
                Nombre = "Nachos",
                Precio = 290,
                TipoMercaderiaId = 1,
                Ingredientes = "Crocantes capas de Nachos al horno, con salsa de especial de tomates, queso fundido, cheddar y verdeo",
                Preparacion = "Acompañados con guacamole, crema ácida, frijol refrito y salsa hot. Una bomba divina.",
                Imagen = "http://malevamag.com/wp-content/uploads/2017/11/Buller_17_rp-1-1200x800.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 6,
                Nombre = "La Causa Chirashi",
                Precio = 300,
                TipoMercaderiaId = 1,
                Ingredientes = "Tartar de pescados, mariscos, masago, palta y salsa acevichada.",
                Preparacion = "Preparada por el chef Eddie Castro, un hit de este restaurante ícono de la cocina Nikkei en la ciudad.",
                Imagen = "http://malevamag.com/wp-content/uploads/2017/11/CHIRASHI-CAUSA-Osaka-1200x800.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 7,
                Nombre = "Milanesas con papas fritas",
                Precio = 250,
                TipoMercaderiaId = 2,
                Ingredientes = "Puede ser de carne de vaca o de pollo y va acompañado de papas fritas gruesas y crocantes.",
                Preparacion = "Fritas.",
                Imagen = "https://neuquen24horas.com/wp-content/uploads/2019/04/436282-24a00532-effe-43a2-a025-27d206875cfb.jpg"
            });
         
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 9,
                Nombre = "Lasaña de verduras",
                Precio = 200,
                TipoMercaderiaId = 3,
                Ingredientes = "Elaborado una bechamel de champiñones que aporta un toque especial al plato.",
                Preparacion = "Una receta italiana en la que se intercalan láminas de pasta con relleno al gusto, se napa con bechamel, terminando su preparación en el horno.",
                Imagen = "https://imag.bonviveur.es/articulos/lasana-de-verduras.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 10,
                Nombre = "Macarrones al horno",
                Precio = 310,
                TipoMercaderiaId = 3,
                Ingredientes = "Una capa de bechamel antes del queso.",
                Preparacion = "Llevan como “extra” una buena dosis de queso gratinado.",
                Imagen = "https://imag.bonviveur.es/articulos/macarrones-al-horno-con-carne-picada.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 11,
                Nombre = "Costillas de cerdo",
                Precio = 350,
                TipoMercaderiaId = 4,
                Ingredientes = "Un costillar de costilla corta de cerdo.",
                Preparacion = "Braseadas con salsa BBQ.",
                Imagen = "https://dam.cocinafacil.com.mx/wp-content/uploads/2015/05/costillas-de-cerdo-barbecue.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 12,
                Nombre = "Pechuga a la parrilla",
                Precio = 250,
                TipoMercaderiaId = 4,
                Ingredientes = "2 pechugas partidas a la mitad.",
                Preparacion = "En una parrilla o sartén caliente asa las pechugas con mantequilla, salpimienta.",
                Imagen = "https://dam.cocinafacil.com.mx/wp-content/uploads/2020/04/pechuga-a-la-parilla.jpg"
            });
           
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 14,
                Nombre = "Pizza pepperoni",
                Precio = 550,
                TipoMercaderiaId = 5,
                Ingredientes = "Se trata de una pizza con base de salsa de tomate, mozzarella y pepperoni.",
                Preparacion = "alami curado hecho a base de carne de cerdo y de vaca mezclados y sazonados con pimentón.",
                Imagen = "https://imag.bonviveur.es/articulos/presentacion-principal-de-la-pizza-pepperoni.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 15,
                Nombre = "White Lady",
                Precio = 150,
                TipoMercaderiaId = 8,
                Ingredientes = "Ginebra, TripleSec, Jugo de limon, Azucar, 1 Clara de huevo.",
                Preparacion = "El cóctel original llevaba crema de menta.",
                Imagen = "https://imag.bonviveur.es/articulos/foto-final-del-coctel-white-lady.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 16,
                Nombre = "Sangría",
                Precio = 120,
                TipoMercaderiaId = 8,
                Ingredientes = "Vino, azúcar, trozos de fruta y alguna bebida carbonatada.",
                Preparacion = "Hay diferentes tipos de sangrías, con vino blanco o con champagne, pero la clásica española es la que se hace con vino tinto.",
                Imagen = "https://imag.bonviveur.es/articulos/foto-principal-sangria.jpg"
            });

            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 17,
                Nombre = "Helado de Oreo",
                Precio = 100,
                TipoMercaderiaId = 10,
                Ingredientes = "Galletas Oreo.",
                Preparacion = "La receta del helado de Oreo que hoy te proponemos tiene pocos ingredientes pues queremos que no le roben el protagonismo a la galleta.",
                Imagen = "https://imag.bonviveur.es/articulos/helado-de-oreo.jpg"
            });
          
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 18,
                Nombre = "Tarta de plátano",
                Precio = 180,
                TipoMercaderiaId = 10,
                Ingredientes = "Platanos.",
                Preparacion = "Una tarta al más puro estilo estadounidense, con una base de masa de pie y un relleno que alterna una crema pastelera enriquecida con plátano fresco en rodajas.",
                Imagen = "https://imag.bonviveur.es/articulos/presentacion-de-la-tarta-de-platano.jpg"
            });
            Mercaderia.HasData(new Mercaderia
            {
                MercaderiaId = 19,
                Nombre = "Ensalada de judías verdes con tomate y huevo cocido",
                Precio = 100,
                TipoMercaderiaId = 7,
                Ingredientes = "La temporada de judías verdes ya llega a su fin y es momento de aprovecharlas.",
                Preparacion = "En esta ensalada, de preparación muy sencilla, las comemos frías y las combinamos con huevo cocido y tomate.",
                Imagen = "https://imag.bonviveur.es/articulos/ensalada-de-judias-verdes-con-tomate-y-huevo-cocido.jpg"
            });








        }

    }
}
