
using System;
using System.Collections.Generic;


namespace Api_Restful.Domain.DTO_s
{
    public class ResponseComandaDto
    {
        public Guid ComandaId { get; set; }
        public List<ResponseMercaderiaDto> Mercaderias { get; set; }
        public string FormaEntrega { get; set; }
        public int FormaEntregaId { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
    }
}
