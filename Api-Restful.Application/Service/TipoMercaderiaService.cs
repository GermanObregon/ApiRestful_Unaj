using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restful.Application.Service
{
    public interface ITipoMercaderiaService
    {
        List<TipoMercaderiaDTO> GetAllTipos();

    }
    public class TipoMercaderiaService : ITipoMercaderiaService
    {
        private readonly ITipoMercaderiaQuery _query;

        public TipoMercaderiaService(ITipoMercaderiaQuery query)
        {
            _query = query;
        }

        public List<TipoMercaderiaDTO> GetAllTipos()
        {
            return _query.GetTipos();
        }
    }
}
