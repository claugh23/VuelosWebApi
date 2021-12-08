using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services.Repositories;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearUsuarioController : ControllerBase
    {

        private CrearUsuarioRepository  _userRepository = new CrearUsuarioRepository();


        [HttpGet]
        public IEnumerable<CrearUsuario> GetUsers()
        {

            return _userRepository.GetAll();
        }

        [HttpPost]
        public void PostUser([FromBody] CrearUsuario usuario)
        {
            if (usuario.IdUsuario != "")
            {
                _userRepository.Add(usuario);
            }

        }
        [HttpPut]
        public Models.CrearUsuario PutUser([FromBody] CrearUsuario update)
        {
            if (update.IdUsuario != "")
            {
                _userRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{IdUsuario}")]
        public string DeleteUser(string IdUsuario)
        {
            if (IdUsuario != "")
            {
                return _userRepository.Delete(IdUsuario);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
