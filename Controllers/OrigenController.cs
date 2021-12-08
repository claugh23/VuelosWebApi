using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigenController : ControllerBase
    {
        private OrigenRepository _OrigenRepository = new OrigenRepository();


        [HttpGet]
        public IEnumerable<Origen> GetUsers()
        {

            return _OrigenRepository.GetAll();
        }

        [HttpPost]
        public void PostUser([FromBody] Origen origen)
        {
            if (origen.Id_Origen != 0)
            {
                _OrigenRepository.Add(origen);
            }

        }
        [HttpPut]
        public Origen PutUser([FromBody] Origen update)
        {
            if (update.Id_Origen != 0)
            {
                _OrigenRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{IdOrigen}")]
        public string DeleteUser(string IdOrigen)
        {
            if (IdOrigen != "")
            {
                return _OrigenRepository.Delete(IdOrigen);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
