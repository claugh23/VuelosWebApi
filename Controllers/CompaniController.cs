using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniController : ControllerBase
    {
        private Services.Repositories.CompaniRepository _companiRepository = new Services.Repositories.CompaniRepository();

        [HttpGet]
        public IEnumerable<Compani> GetCompanis()
        {

            return (IEnumerable<Compani>)_companiRepository.GetAll();
        }

        [HttpPost]
        public void PostCompani([FromBody] Compani usuario)
        {
            if (usuario.Id_Compani != 0)
            {
                _companiRepository.Add(usuario);
            }

        }
        [HttpPut]
        public Models.Compani PutCompani([FromBody] Compani update)
        {
            if (update.Id_Compani != 0)
            {
                _companiRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{Id_Compani}")]
        public string DeleteCompani(int id_Companie)
        {
            if (id_Companie != 0)
            {
                return _companiRepository.Delete(id_Companie);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
