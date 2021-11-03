

using Api_Restful.Domain.DTO_s;
using System.Collections.Generic;

namespace Api_Restful.AccesData.Queries.Repository
{
    public interface IMercaderiaQuery
    {
        ResponseMercaderiaDto GetMercaderiaById(int id);
        List<ResponseMercaderiaDto> GetAllMercaderiasByTipo(int id);
        List<ResponseMercaderiaDto> GetAllMercaderias();

        ResponseCantTiposMercaderias GetCantidadTipos();
    }
}
