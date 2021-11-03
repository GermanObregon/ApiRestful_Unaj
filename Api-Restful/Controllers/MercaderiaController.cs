using Api_Restful.AccesData.Validations;
using Api_Restful.Application.Service;
using Api_Restful.Domain.DTO_s;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Api_Restful.Controllers
{
    [ApiController]
    [Route("api/Mercaderia")]
    public class MercaderiaController : ControllerBase
    {
        private readonly IMercaderiaService _service;
        public MercaderiaController(IMercaderiaService service)
        {
            this._service = service;
        }
        [HttpPost]
        public IActionResult AddMercaderia(MercaderiaDto Mercaderia)
        {
            try
            {
                return new JsonResult (_service.AgregarMercaderia(Mercaderia)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = new ExceptionRequest().Request(e) });
            }
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] int tipo)
        {
            if (tipo == 0)
            {
                return new JsonResult(_service.ObtenerMercaderias()) { StatusCode = 200 };
            }
            if (tipo <= _service.CantidadTipos().Cantidad && tipo > 0)
            {
                return new JsonResult(_service.ObtenerMercaderiasPorTipo(tipo)) { StatusCode = 200 };
            }

            return NotFound(new { error = "No se encuentra en la Base de Datos" });
         
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return new JsonResult(_service.ObtenerMercaderiaPorId( id)) { StatusCode = 200 };
            }
            catch (Exception)
            {
                

                return NotFound(new { error = "No se encuentra en la Base de Datos" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMercaderia(MercaderiaDto Mercaderia , int id)
        {
            try
            {
                return new JsonResult(_service.ActulizarMercaderia(Mercaderia , id)) { StatusCode = 200 };
            }
            catch (Exception )
            {

                return NotFound(new { error = "No se encuentra en la Base de Datos" });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMercaderia(int id)
        {
            try
            {
                _service.BorrarMercaderia(id);
                return Ok();
            }
            catch (Exception)
            {

                return NotFound(new { error = "No se encuentra en la Base de Datos" });
            }
        }

    }
}
