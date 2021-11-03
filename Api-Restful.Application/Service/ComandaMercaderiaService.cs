using Api_Restful.AccesData.Command.Repository;
using Api_Restful.Domain.Entities;

using System.Collections.Generic;


namespace Api_Restful.Application.Service
{
    public interface IcomandaMercaderiaService
    {
        void FinalizarPedido(Comanda comanda, List<Mercaderia> mercaderias);

    }

    public class ComandaMercaderiaService : IcomandaMercaderiaService
    {
        private readonly IGenericRepository _repository;

        public ComandaMercaderiaService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public void FinalizarPedido(Comanda comanda, List<Mercaderia> mercaderias)
        {
            foreach (Mercaderia item in mercaderias)
            {
                var comandaMercaderia = new ComandaMercaderia
                {
                    MercaderiaId = item.MercaderiaId,
                    ComandaId = comanda.ComandaId,
                };
                _repository.Add<ComandaMercaderia>(comandaMercaderia);
            }
            
        }
    }
}
