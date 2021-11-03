using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restful.Application.Service
{
    public interface IFormaEntregaService
    {
        List<FormaEntregaDTO> GetAllFormas();

    }
    public class FormaEntregaService : IFormaEntregaService
    {
        private readonly IFormaEntregaQuery _query;

        public FormaEntregaService(IFormaEntregaQuery query)
        {
            _query = query;
        }

        public List<FormaEntregaDTO> GetAllFormas()
        {
            return _query.GetAllFormaEntregas();
        }
    }
}
