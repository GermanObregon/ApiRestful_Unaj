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
    public class FormaEntregaQuery : IFormaEntregaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;

        public FormaEntregaQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            SqlKata = sqlKata;
        }

        public List<FormaEntregaDTO> GetAllFormaEntregas()
        {
            var Db = new QueryFactory(connection, SqlKata);

            var query = Db.Query("FormaEntrega")
                .Select("FormaEntregaId", "Descripcion");


            var result = query.Get<FormaEntregaDTO>().ToList();

            return result;
        }
    }
}
