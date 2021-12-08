using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Services;
using VuelosWebApi.Models;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private TipoUsuarioRepository _TipoUsuarioRepository = new TipoUsuarioRepository();


        [HttpGet]
        public IEnumerable<TipoUsuario> GetUsers()
        {

            return _TipoUsuarioRepository.GetAll();
        }

        [HttpPost]
        public void PostUser([FromBody] TipoUsuario tipoUsuario)
        {
            if (tipoUsuario.IdTiposUsuarios != 0)
            {
                _TipoUsuarioRepository.Add(tipoUsuario);
            }

        }
        [HttpPut]
        public TipoUsuario PutUser([FromBody] TipoUsuario update)
        {
            if (update.IdTiposUsuarios != 0)
            {
                _TipoUsuarioRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{IdOrigen}")]
        public string DeleteUser(int Id_tipoUsuario)
        {
            if (Id_tipoUsuario != 0)
            {
                return _TipoUsuarioRepository.Delete(Id_tipoUsuario);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
