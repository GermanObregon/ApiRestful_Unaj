using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.Domain.DTO_s;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restful.AccesData.Queries
{
    public class TipoMercaderiaQuery : ITipoMercaderiaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;

        public TipoMercaderiaQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            SqlKata = sqlKata;
        }

        public List<TipoMercaderiaDTO> GetTipos()
        {
            var Db = new QueryFactory(connection, SqlKata);

            var query = Db.Query("TipoMercaderia")
                .Select("TipoMercaderiaId", "Descripcion");


            var result = query.Get<TipoMercaderiaDTO>().ToList();

            return result;
        }
    }
}
