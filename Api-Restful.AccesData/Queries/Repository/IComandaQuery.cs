using Api_Restful.Domain.DTO_s;
using System;
using System.Collections.Generic;

namespace Api_Restful.AccesData.Queries.Repository
{
    public interface IComandaQuery
    {
        ResponseCantFormaEntregas GetCantidadFormas();
        ResponseComandaDto GetById(Guid id);
        List<ComandaDto> GetAllByFecha(DateTime fecha);
    }
}
