using Api_Restful.AccesData.Command.Repository;
using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.AccesData.Validations;
using Api_Restful.Domain.DTO_s;
using Api_Restful.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace Api_Restful.Application.Service
{
    public interface IMercaderiaService
    {
        MercaderiaDto AgregarMercaderia(MercaderiaDto NuevaMercaderia);
        MercaderiaDto ActulizarMercaderia(MercaderiaDto Mercaderia , int id);
        void BorrarMercaderia(int id);
        ResponseMercaderiaDto ObtenerMercaderiaPorId(int id);
        List<ResponseMercaderiaDto> ObtenerMercaderiasPorTipo(int tipo);
        List<ResponseMercaderiaDto> ObtenerMercaderias();
        ResponseCantTiposMercaderias CantidadTipos();

    }
    public class MercaderiaService : IMercaderiaService
    {
        private readonly IGenericRepository _repository;
        private readonly IMercaderiaQuery _query;
        
        public MercaderiaService(IGenericRepository repository , IMercaderiaQuery query)
        {
            this._repository = repository;
            this._query = query;
        }

        public MercaderiaDto ActulizarMercaderia(MercaderiaDto Mercaderia , int id)
        {
            var validator = new MercaderiaValidator(_query);
            validator.ValidateAndThrow(Mercaderia);

            var mer = new Mercaderia
            {
                MercaderiaId = id,
                Nombre = Mercaderia.Nombre,
                Precio = Mercaderia.Precio,
                Preparacion = Mercaderia.Preparacion,
                Imagen = Mercaderia.Imagen,
                Ingredientes = Mercaderia.Ingredientes,
                TipoMercaderiaId = Mercaderia.TipoMercaderiaId

            };
            _repository.Update<Mercaderia>(mer);

            var response = new MercaderiaDto
            {
                MercaderiaId = mer.MercaderiaId,
                Nombre = mer.Nombre,
                Precio = mer.Precio,
                Preparacion = mer.Preparacion,
                Imagen = mer.Imagen,
                TipoMercaderiaId = mer.TipoMercaderiaId,
                Ingredientes = mer.Ingredientes

            };

            return response;
        }

        public MercaderiaDto AgregarMercaderia(MercaderiaDto NuevaMercaderia)
        {
            var validator = new MercaderiaValidator(_query);
            validator.ValidateAndThrow(NuevaMercaderia);
           
            var mer = new Mercaderia
            {
                Nombre = NuevaMercaderia.Nombre,
                Precio = NuevaMercaderia.Precio,
                Preparacion = NuevaMercaderia.Preparacion,
                Imagen = NuevaMercaderia.Imagen,
                Ingredientes = NuevaMercaderia.Ingredientes,
                TipoMercaderiaId = NuevaMercaderia.TipoMercaderiaId
                
            };
             _repository.Add<Mercaderia>(mer);

            var response = new MercaderiaDto
            {
                MercaderiaId = mer.MercaderiaId,
                Nombre = mer.Nombre,
                Precio = mer.Precio,
                Preparacion = mer.Preparacion,
                Imagen = mer.Imagen,
                TipoMercaderiaId = mer.TipoMercaderiaId,
                Ingredientes = mer.Ingredientes

            };

            return response;
        }

        public void BorrarMercaderia(int id)
        {
            _repository.Delete<Mercaderia>(id);
        }

        public ResponseCantTiposMercaderias CantidadTipos()
        {
            return _query.GetCantidadTipos();
        }

        public ResponseMercaderiaDto ObtenerMercaderiaPorId(int id)
        {

            return _query.GetMercaderiaById(id);
        }

        public List<ResponseMercaderiaDto> ObtenerMercaderias()
        {
            return _query.GetAllMercaderias();
        }

        public List<ResponseMercaderiaDto> ObtenerMercaderiasPorTipo(int tipo)
        {

            return _query.GetAllMercaderiasByTipo(tipo);
        }
    }
}
