using Api_Restful.AccesData.Command.Repository;
using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.Domain.DTO_s;
using Api_Restful.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Api_Restful.Application.Service
{
    public interface IComandaService
    {
        ResponseCantFormaEntregas GetCantidadFormasEntregas();
        ResponseComandaDto AgregarPedido(PedidoDto pedido);
        ResponseComandaDto GetComandaById(Guid id);
        List<ResponseComandaDto> GetAllComandasByFecha(DateTime fecha);
        

    }
    public class ComandaService : IComandaService
    {
        private readonly IGenericRepository _repository;
        private readonly IComandaQuery _query;
        private readonly IMercaderiaQuery _queryMercaderia;
        private readonly IcomandaMercaderiaService _comandaMercaderiaService;
        public ComandaService(IGenericRepository repository, IComandaQuery query , IMercaderiaQuery queryMercaderia , IcomandaMercaderiaService comandaMercaderiaService)
        {
            _repository = repository;
            _query = query;
            _queryMercaderia = queryMercaderia;
            _comandaMercaderiaService = comandaMercaderiaService;
        }

        public ResponseComandaDto AgregarPedido(PedidoDto pedido)
        {
            var verificarMercaderias = new VerificarMercaderias(pedido.Mercaderias , _queryMercaderia);
            var listaMercaderias = verificarMercaderias.Verificar();
            
            var comanda = new Comanda
            {
                ComandaId = new Guid(),
                FormaEntregaId = pedido.FormaEntrega,
                Fecha = DateTime.Now.Date,
                PrecioTotal = verificarMercaderias.PrecioTotal
            };

            _repository.Add<Comanda>(comanda);
            _comandaMercaderiaService.FinalizarPedido(comanda, listaMercaderias);

            
            var query = _query.GetById(comanda.ComandaId);

            return query;


        }

        public List<ResponseComandaDto> GetAllComandasByFecha(DateTime fecha)
        {
            List<ResponseComandaDto> lista = new List<ResponseComandaDto>();
            var listaComandas = _query.GetAllByFecha(fecha);
            foreach (ComandaDto item in listaComandas)
            {
                var comanda = _query.GetById(item.ComandaId);
                lista.Add(comanda);
            }
            return lista;
        }

        public ResponseCantFormaEntregas GetCantidadFormasEntregas()
        {
            return _query.GetCantidadFormas();
        }

        public ResponseComandaDto GetComandaById(Guid id)
        {
            return _query.GetById(id);
        }
    }
}
