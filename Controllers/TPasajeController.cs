using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPasajeController : ControllerBase
    {
        private TPasajesRepository _TPasajesRepository = new TPasajesRepository();


        [HttpGet]
        public IEnumerable<TPasaje> GetPasaje()
        {

            return _TPasajesRepository.GetAll();
        }

        [HttpPost]
        public void PostPasaje([FromBody] TPasaje pasaje)
        {
            if (pasaje.Id_pasaje != 0)
            {
                _TPasajesRepository.Add(pasaje);
            }

        }
        [HttpPut]
        public TPasaje PutPasaje([FromBody] TPasaje update)
        {
            if (update.Id_pasaje != 0)
            {
                _TPasajesRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{Id_pasaje}")]
        public string DeletePasaje(int idpasaje)
        {
            if (idpasaje != 0)
            {
                return _TPasajesRepository.Delete(idpasaje);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
