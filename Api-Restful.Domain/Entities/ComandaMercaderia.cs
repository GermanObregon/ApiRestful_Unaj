
using System;

namespace Api_Restful.Domain.Entities
{
    public class ComandaMercaderia
    {
        public Guid ComandaId { get; set; }
        public int ComandaMercaderiaId { get; set; }
        public Comanda Comanda { get; set; }
        public int MercaderiaId { get; set; }
        public Mercaderia Mercaderia { get; set; }


    }
}
