using Api_Restful.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Restful.Controllers
{
    [ApiController]
    [Route("api/FormaEntrega")]
    public class FormaEntregaController : ControllerBase
    {
        private readonly IFormaEntregaService _service;

        public FormaEntregaController(IFormaEntregaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getTipos()
        {
            try
            {
                return new JsonResult(_service.GetAllFormas());
            }
            catch (Exception)
            {

                return BadRequest(new { error = "No se encuentra" });
            }

        }

    }
}
