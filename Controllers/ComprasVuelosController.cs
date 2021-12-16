using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasVuelosController : ControllerBase
    {
        private ComprasVuelosRepository _comprasVuelosRepository = new ComprasVuelosRepository();
        private Random _random = new Random();

        [HttpGet]
        public IActionResult GetAllComprasVuelos()
        {

            return Ok(_comprasVuelosRepository.GetAllComprasVuelos());
        }

        [HttpPost]
        public IActionResult PostCompraVuelos([FromBody] ComprasVuelos nuevoVuelo)
        {

            nuevoVuelo.Id_CompraVuelo = _random.Next(1,10000);
        
            if (nuevoVuelo.Id_CompraVuelo != 0)
            {
                _comprasVuelosRepository.PostVueloCompra(nuevoVuelo);

                return Ok("La compra del vuelo fue exitosa!");
            }
            else
            {
                return BadRequest("Ocurrio un error al comprar el vuelo");
            }
        }
    }
}
