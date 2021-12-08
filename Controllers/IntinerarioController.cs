using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntinerarioController : ControllerBase
    {
        private IntinerarioRepository _IntinerarioRepository = new IntinerarioRepository();


        [HttpGet]
        public IEnumerable<Intinerario> GetUsers()
        {

            return _IntinerarioRepository.GetAll();
        }

        [HttpPost]
        public void PostUser([FromBody] Intinerario intinerario)
        {
            if (intinerario.Id_Intinerario != 0)
            {
                _IntinerarioRepository.Add(intinerario);
            }

        }
        [HttpPut]
        public Intinerario PutUser([FromBody] Intinerario update)
        {
            if (update.Id_Intinerario != 0)
            {
                _IntinerarioRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{IdIntinerario}")]
        public string DeleteUser(string IdIntinerario)
        {
            if (IdIntinerario != "")
            {
                return _IntinerarioRepository.Delete(IdIntinerario);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
