using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private VueloRepository _VueloRepository = new VueloRepository();


        [HttpGet]
        public IEnumerable<Vuelo> GetUsers()
        {

            return _VueloRepository.GetAll();
        }

        [HttpPost]
        public void PostVuelo([FromBody] Vuelo usuario)
        {
            if (usuario.Id_Vuelo != 0)
            {
                _VueloRepository.Add(usuario);
            }

        }
        [HttpPut]
        public Vuelo PutVuelo([FromBody] Vuelo update)
        {
            if (update.Id_Vuelo != 0)
            {
                _VueloRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{IdUsuario}")]
        public string DeleteVuelo(int IdUsuario)
        {
            if (IdUsuario != 0)
            {
                return _VueloRepository.Delete(IdUsuario);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
