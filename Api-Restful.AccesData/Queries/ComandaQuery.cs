using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.Domain.DTO_s;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Api_Restful.AccesData.Queries
{
    public class ComandaQuery : IComandaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;

        public ComandaQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            SqlKata = sqlKata;
        }

        public List<ComandaDto> GetAllByFecha(DateTime fecha)
        {
            var Db = new QueryFactory(connection, SqlKata);
            var query = Db.Query("Comanda")
                .Join("FormaEntrega", "FormaEntrega.FormaEntregaId", "Comanda.FormaEntregaId")
                .Select("ComandaId", "Fecha", "PrecioTotal", "Comanda.FormaEntregaId AS FormaEntregaId", "FormaEntrega.Descripcion AS FormaEntrega")
                .Where("Comanda.Fecha", "=", fecha);

            var results = query.Get<ComandaDto>().ToList();
            return results;
                

        }

        public ResponseComandaDto GetById(Guid id)
        {
            var Db = new QueryFactory(connection, SqlKata);
            var query = Db.Query("Comanda")
                .Join("FormaEntrega", "FormaEntrega.FormaEntregaId", "Comanda.FormaEntregaId")
                .Select("ComandaId", "Fecha", "PrecioTotal","Comanda.FormaEntregaId AS FormaEntregaId", "FormaEntrega.Descripcion AS FormaEntrega")
                .Where("ComandaId", "=", id)
                .First<ComandaDto>();

            var query2 = Db.Query("ComandaMercaderia")
                .Join("Mercaderia" , "Mercaderia.MercaderiaId","ComandaMercaderia.MercaderiaId")
                .Join("TipoMercaderia","TipoMercaderia.TipoMercaderiaId","Mercaderia.TipoMercaderiaId")
                .Select("Mercaderia.MercaderiaId","Mercaderia.Nombre" , "Mercaderia.Precio" , "Mercaderia.Preparacion","Mercaderia.Ingredientes","Mercaderia.Imagen" ,
                        "Mercaderia.TipoMercaderiaId AS TipoId" , "TipoMercaderia.Descripcion AS TipoMercaderia")
                .Where("ComandaId", "=", id);

            var listaMercaderia = query2.Get<ResponseMercaderiaDto>().ToList();
           
            var Comanda = new ResponseComandaDto
            {
                ComandaId = query.ComandaId,
                FormaEntrega =  query.FormaEntrega,
                FormaEntregaId = query.FormaEntregaId,
                Fecha = query.Fecha,
                PrecioTotal = query.PrecioTotal,
                Mercaderias = listaMercaderia
            };
            
            return Comanda;
        }

        public ResponseCantFormaEntregas GetCantidadFormas()
        {
            var Db = new QueryFactory(connection, SqlKata);
            var query = Db.Query("FormaEntrega").Select().SelectRaw("count(*) Cantidad")
                .First<ResponseCantFormaEntregas>();


            return query;
        }
    }
}
