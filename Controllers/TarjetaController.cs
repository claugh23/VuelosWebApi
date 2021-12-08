using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private TarjetaRepository _TarjetaRepository = new TarjetaRepository();


        [HttpGet]
        public IEnumerable<Tarjeta> GetUsers()
        {

            return _TarjetaRepository.GetAll();
        }

        [HttpPost]
        public void PostTarjeta([FromBody] Tarjeta tarjeta)
        {
            if (tarjeta.Id_Pago != 0)
            {
                _TarjetaRepository.Add(tarjeta);
            }

        }
        [HttpPut]
        public Tarjeta PutTarjeta([FromBody] Tarjeta update)
        {
            if (update.Id_Pago != 0)
            {
                _TarjetaRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{IdTarjeta}")]
        public string DeleteTarjeta(string IdTarjeta)
        {
            if (IdTarjeta != "")
            {
                return _TarjetaRepository.Delete(IdTarjeta);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
