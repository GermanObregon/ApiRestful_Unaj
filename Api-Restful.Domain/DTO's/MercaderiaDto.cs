

namespace Api_Restful.Domain.DTO_s
{
    public class MercaderiaDto
    {
        public int MercaderiaId { get; set; }
        public string Nombre { get; set; }
        public int TipoMercaderiaId { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacion { get; set; }
        public string Imagen { get; set; }
    }
}
