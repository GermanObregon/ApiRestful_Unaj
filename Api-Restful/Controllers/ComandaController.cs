using Api_Restful.Application.Service;
using Api_Restful.Domain.DTO_s;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_Restful.Controllers
{
    [ApiController]
    [Route("api/Comanda")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _service;
        public ComandaController(IComandaService service)
        {
            this._service = service;
        }

        [HttpPost]
        public IActionResult CreateComanda(PedidoDto pedido)
        {
            if (pedido.FormaEntrega <= _service.GetCantidadFormasEntregas().Cantidad && pedido.FormaEntrega > 0)
            {
                try
                {
                    if (pedido.Mercaderias.Length != 0)
                    {
                        return new JsonResult(_service.AgregarPedido(pedido)) { StatusCode = 201 };
                    }
                    else
                    {
                        return BadRequest(new { error = "La lista no puede estar vacia" });
                    }
                    
                }
                catch (Exception)
                {

                    return NotFound(new { error = "Una de las Mercaderias no se encuentra en la base de datos" });
                }

            }
            else
            {
                return BadRequest(new { error = "Forma de Entrega no valida" });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetComandaById(string id)
        {
            try
            {
                return new JsonResult(_service.GetComandaById(Guid.Parse(id))) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return NotFound(new { error = "No se encuentra camanda en la base de datos" });
            }
        }
        [HttpGet]
        public IActionResult GetComandaFecha([FromQuery] DateTime fecha)
        {
            return new JsonResult(_service.GetAllComandasByFecha(fecha)) { StatusCode = 200 };
           
        }



    }
}
