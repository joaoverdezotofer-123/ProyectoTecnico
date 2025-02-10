using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PruebaTecnica.Models;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Usuario>> Register(Usuario usuario)
        {
            var createdUsuario = await _usuariosService.CreateUsuarioAsync(usuario);
            return CreatedAtAction(nameof(Register), new { id = createdUsuario.Identificador }, createdUsuario);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Usuario usuario)
        {
            var token = await _usuariosService.AuthenticateAsync(usuario.NombreUsuario, usuario.Pass);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}