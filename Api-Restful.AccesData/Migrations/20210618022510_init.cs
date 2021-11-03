using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Restful.AccesData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comanda_FormaEntrega_FormaEntregaId",
                        column: x => x.FormaEntregaId,
                        principalTable: "FormaEntrega",
                        principalColumn: "FormaEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderia",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderia", x => x.MercaderiaId);
                    table.ForeignKey(
                        name: "FK_Mercaderia_TipoMercaderia_TipoMercaderiaId",
                        column: x => x.TipoMercaderiaId,
                        principalTable: "TipoMercaderia",
                        principalColumn: "TipoMercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderia",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => x.ComandaMercaderiaId);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Mercaderia_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderia",
                        principalColumn: "MercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cervezas Artesanales" },
                    { 10, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderia",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 1, "http://malevamag.com/wp-content/uploads/2017/11/Ceviche-cremosos-Puerta-del-Inca-1200x800.jpg", "dados de salmón marinados en jugo de lima, crema de ají amarillo, chips y maíz frito", "Ceviche Cremoso", 250, "Un plató típico de la gastronomía peruana", 1 },
                    { 16, "https://imag.bonviveur.es/articulos/foto-principal-sangria.jpg", "Vino, azúcar, trozos de fruta y alguna bebida carbonatada.", "Sangría", 120, "Hay diferentes tipos de sangrías, con vino blanco o con champagne, pero la clásica española es la que se hace con vino tinto.", 8 },
                    { 15, "https://imag.bonviveur.es/articulos/foto-final-del-coctel-white-lady.jpg", "Ginebra, TripleSec, Jugo de limon, Azucar, 1 Clara de huevo.", "White Lady", 150, "El cóctel original llevaba crema de menta.", 8 },
                    { 19, "https://imag.bonviveur.es/articulos/ensalada-de-judias-verdes-con-tomate-y-huevo-cocido.jpg", "La temporada de judías verdes ya llega a su fin y es momento de aprovecharlas.", "Ensalada de judías verdes con tomate y huevo cocido", 100, "En esta ensalada, de preparación muy sencilla, las comemos frías y las combinamos con huevo cocido y tomate.", 7 },
                    { 14, "https://imag.bonviveur.es/articulos/presentacion-principal-de-la-pizza-pepperoni.jpg", "Se trata de una pizza con base de salsa de tomate, mozzarella y pepperoni.", "Pizza pepperoni", 550, "alami curado hecho a base de carne de cerdo y de vaca mezclados y sazonados con pimentón.", 5 },
                    { 12, "https://dam.cocinafacil.com.mx/wp-content/uploads/2020/04/pechuga-a-la-parilla.jpg", "2 pechugas partidas a la mitad.", "Pechuga a la parrilla", 250, "En una parrilla o sartén caliente asa las pechugas con mantequilla, salpimienta.", 4 },
                    { 11, "https://dam.cocinafacil.com.mx/wp-content/uploads/2015/05/costillas-de-cerdo-barbecue.jpg", "Un costillar de costilla corta de cerdo.", "Costillas de cerdo", 350, "Braseadas con salsa BBQ.", 4 },
                    { 17, "https://imag.bonviveur.es/articulos/helado-de-oreo.jpg", "Galletas Oreo.", "Helado de Oreo", 100, "La receta del helado de Oreo que hoy te proponemos tiene pocos ingredientes pues queremos que no le roben el protagonismo a la galleta.", 10 },
                    { 10, "https://imag.bonviveur.es/articulos/macarrones-al-horno-con-carne-picada.jpg", "Una capa de bechamel antes del queso.", "Macarrones al horno", 310, "Llevan como “extra” una buena dosis de queso gratinado.", 3 },
                    { 7, "https://neuquen24horas.com/wp-content/uploads/2019/04/436282-24a00532-effe-43a2-a025-27d206875cfb.jpg", "Puede ser de carne de vaca o de pollo y va acompañado de papas fritas gruesas y crocantes.", "Milanesas con papas fritas", 250, "Fritas.", 2 },
                    { 6, "http://malevamag.com/wp-content/uploads/2017/11/CHIRASHI-CAUSA-Osaka-1200x800.jpg", "Tartar de pescados, mariscos, masago, palta y salsa acevichada.", "La Causa Chirashi", 300, "Preparada por el chef Eddie Castro, un hit de este restaurante ícono de la cocina Nikkei en la ciudad.", 1 },
                    { 5, "http://malevamag.com/wp-content/uploads/2017/11/Buller_17_rp-1-1200x800.jpg", "Crocantes capas de Nachos al horno, con salsa de especial de tomates, queso fundido, cheddar y verdeo", "Nachos", 290, "Acompañados con guacamole, crema ácida, frijol refrito y salsa hot. Una bomba divina.", 1 },
                    { 4, "http://malevamag.com/wp-content/uploads/2017/11/Pizza-Frita-Ike-Milano-1200x800.jpg", "Sale con mozzarella, tomate y albahaca fresca", "Pizza Frita Margherita", 140, "Un plato típico de la cocina callejera napolitana.", 1 },
                    { 3, "http://malevamag.com/wp-content/uploads/2017/11/Empanada-de-Ciervo-Alos-1198x800.jpg", "La masa es casera y el relleno se prepara con carne de ciervo que fue braseado por muchas horas.", "Empanadas de Ciervo", 195, "Se sirve con una fresca ensalada de rabanitos y verdes, más una salsa de tomates con limón que potencia todos los sabores.", 1 },
                    { 2, "http://malevamag.com/wp-content/uploads/2017/11/Inmigrante_12__rp-1200x800.jpg", "Jamón marinado y glaseado a la parrilla, huevo a baja temperatura con polvo de aceitunas negras, salteado de arvejas, cebolla encurtida y papas fritas a la provenzal.", "Gramajo", 195, "Una receta que data de la época de la gran inmigración europea a la Argentina y que constituye un clásico de nuestra gastronomía.", 1 },
                    { 9, "https://imag.bonviveur.es/articulos/lasana-de-verduras.jpg", "Elaborado una bechamel de champiñones que aporta un toque especial al plato.", "Lasaña de verduras", 200, "Una receta italiana en la que se intercalan láminas de pasta con relleno al gusto, se napa con bechamel, terminando su preparación en el horno.", 3 },
                    { 18, "https://imag.bonviveur.es/articulos/presentacion-de-la-tarta-de-platano.jpg", "Platanos.", "Tarta de plátano", 180, "Una tarta al más puro estilo estadounidense, con una base de masa de pie y un relleno que alterna una crema pastelera enriquecida con plátano fresco en rodajas.", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FormaEntregaId",
                table: "Comanda",
                column: "FormaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_ComandaId",
                table: "ComandaMercaderia",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_MercaderiaId",
                table: "ComandaMercaderia",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderia_TipoMercaderiaId",
                table: "Mercaderia",
                column: "TipoMercaderiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaMercaderia");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Mercaderia");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
