using System;


namespace Api_Restful.Domain.DTO_s
{
    public class ComandaDto
    {
        public Guid ComandaId { get; set; }
        public int FormaEntregaId { get; set; }
        public string FormaEntrega { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
    }
}
