using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private DestinoRepository _destinoRepository = new DestinoRepository();


        [HttpGet]
        public IEnumerable<Destino> GetDestino()
        {

            return _destinoRepository.GetAll();
        }

        [HttpPost]
        public void PostDestino([FromBody] Destino destino)
        {
            if (destino.Id_Destino != 0)
            {
                _destinoRepository.Add(destino);
            }

        }
        [HttpPut]
        public Destino PutDestino([FromBody] Destino update)
        {
            if (update.Id_Destino != 0)
            {
                _destinoRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{IdUsuario}")]
        public string DeleteDestino(int IdUsuario)
        {
            if (IdUsuario != 0)
            {
                return _destinoRepository.Delete(IdUsuario);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
