using Api_Restful.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Restful.Controllers
{
    [ApiController]
    [Route("api/Tipo")]
    public class TipoMercaderiaController : ControllerBase
    {
        private readonly ITipoMercaderiaService _service;

        public TipoMercaderiaController(ITipoMercaderiaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getTipos()
        {
            try
            {
               return new JsonResult( _service.GetAllTipos());
            }
            catch (Exception)
            {

                return BadRequest(new { error = "No se encuentra" });
            }
             
        }
    }
}
