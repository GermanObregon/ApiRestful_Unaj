

using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.Domain.DTO_s;
using SqlKata.Compilers;
using SqlKata.Execution;

using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Api_Restful.AccesData.Queries
{
    public class MercaderiaQuery : IMercaderiaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;

        public MercaderiaQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            SqlKata = sqlKata;
        }

        public ResponseMercaderiaDto GetMercaderiaById(int id)
        {
            var Db = new QueryFactory(connection, SqlKata);

            var query = Db.Query("Mercaderia")
                .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderia.TipoMercaderiaId")
                .Select("MercaderiaId", "Nombre", "Precio", "Preparacion", "TipoMercaderia.TipoMercaderiaId AS TipoId" , "Ingredientes", "Imagen", "TipoMercaderia.Descripcion AS TipoMercaderia")
                .Where("Mercaderia.MercaderiaId", "=", id);

            var result = query.First<ResponseMercaderiaDto>();

            return result;
        }

        public List<ResponseMercaderiaDto> GetAllMercaderiasByTipo(int id)
        {
            var Db = new QueryFactory(connection, SqlKata);
            var query = Db.Query("Mercaderia")
                .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderia.TipoMercaderiaId")
                .Select("MercaderiaID", "Nombre", "Precio", "Preparacion", "Ingredientes", "Imagen", "TipoMercaderia.TipoMercaderiaId AS TipoId", "TipoMercaderia.Descripcion AS Tipomercaderia")
                .Where("Mercaderia.TipoMercaderiaId", "=", id);

            var results = query.Get<ResponseMercaderiaDto>().ToList();
            return results;
        }

        public List<ResponseMercaderiaDto> GetAllMercaderias()
        {
            var Db = new QueryFactory(connection, SqlKata);
            var query = Db.Query("Mercaderia")
                .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderia.TipoMercaderiaId")
                .Select("MercaderiaID", "Nombre", "Precio", "Preparacion", "Ingredientes", "Imagen","TipoMercaderia.TipoMercaderiaId AS TipoId", "TipoMercaderia.Descripcion AS Tipomercaderia");


            var results = query.Get<ResponseMercaderiaDto>().ToList();
            return results;
        }

        public ResponseCantTiposMercaderias GetCantidadTipos()
        {
            var Db = new QueryFactory(connection, SqlKata);
            var query = Db.Query("TipoMercaderia").Select().SelectRaw("count(*) Cantidad")
                .First<ResponseCantTiposMercaderias>();


            return query;
        }

    }
}
