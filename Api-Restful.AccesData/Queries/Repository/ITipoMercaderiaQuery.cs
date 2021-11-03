using Api_Restful.Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restful.AccesData.Queries.Repository
{
    public interface ITipoMercaderiaQuery
    {
        List<TipoMercaderiaDTO> GetTipos();
    }
}
