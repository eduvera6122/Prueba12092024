using Microsoft.AspNetCore.Mvc;
using Prueba12092024.Models.DTO;
using Prueba12092024.Services.UsuarioServices;


namespace Prueba12092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] Login login)
        {
            if(login == null)
            {
                return BadRequest();
            }

            return Ok(_usuarioService.login(login));

        }

        [HttpPost("register")]
        public IActionResult crearUsuario([FromBody] UsuarioDTO usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            return Ok(_usuarioService.crearUsuario(usuario));

        }






    }
}
