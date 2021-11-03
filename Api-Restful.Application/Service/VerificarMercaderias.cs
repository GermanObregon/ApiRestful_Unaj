using Api_Restful.AccesData.Queries.Repository;

using Api_Restful.Domain.Entities;

using System.Collections.Generic;


namespace Api_Restful.Application.Service
{
    public class VerificarMercaderias
    {
        private readonly IMercaderiaQuery _mercaderiaQuery;
        private readonly int[] _listaMercaderiasDto;
        public int PrecioTotal { get; set; }
        

        public VerificarMercaderias(int[] listaMercaderiasDto , IMercaderiaQuery mercaderiaQuery )
        {
            _listaMercaderiasDto = listaMercaderiasDto;
            _mercaderiaQuery = mercaderiaQuery;
        }

        public List<Mercaderia> Verificar()
        {
            List<Mercaderia> mercaderias = new List<Mercaderia>();
            foreach (int item in _listaMercaderiasDto)
            {
                var MercaderiaVerificada = _mercaderiaQuery.GetMercaderiaById(item);
                var NuevaMercaderia = new Mercaderia
                {
                    MercaderiaId = MercaderiaVerificada.MercaderiaId,
                    Nombre = MercaderiaVerificada.Nombre,
                    Precio = MercaderiaVerificada.Precio,
                    Preparacion = MercaderiaVerificada.Preparacion,
                    Ingredientes = MercaderiaVerificada.Ingredientes,
                    Imagen = MercaderiaVerificada.Imagen,
                    TipoMercaderiaId = MercaderiaVerificada.TipoId


                };
                mercaderias.Add(NuevaMercaderia);
                PrecioTotal += MercaderiaVerificada.Precio;
            }

            return mercaderias;

        }
    }
    
}    

