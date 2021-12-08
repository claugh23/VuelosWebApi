using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private UsuarioRepository _usuarioRepository = new UsuarioRepository();


        [HttpGet]
        public IEnumerable<Usuarios> GetUsers()
        {

            return _usuarioRepository.GetAll();
        }

        [HttpPost]
        public void PostUser([FromBody] Usuarios usuario)
        {
            if (usuario.Id_Cliente != 0)
            {
                _usuarioRepository.Add(usuario);
            }

        }
        [HttpPut]
        public Usuarios PutUser([FromBody] Usuarios update)
        {
            if (update.Id_Cliente != 0)
            {
                _usuarioRepository.Update(update);

                return update;
            }
            else
            {
                return null;
            }
        }
        [HttpDelete("{IdUsuario}")]
        public string DeleteUser(int IdUsuario)
        {
            if (IdUsuario != 0)
            {
                return _usuarioRepository.Delete(IdUsuario);

            }
            else
            {
                return "id invalido o nulo";
            }
        }
    }
}
