using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VuelosWebApi.Models;
using VuelosWebApi.Services;

namespace VuelosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErroresController : ControllerBase
    {
        private ErroresRepository _errorRepository = new ErroresRepository();


        [HttpGet]
        public IEnumerable<Errores> GetUsers()
        {

            return _errorRepository.GetAll();
        }

        [HttpPost]
        public void PostUser([FromBody] Errores error)
        {
            if (error.id_error != 0)
            {
                _errorRepository.Add(error);
            }

        }
    
       
    }
}
