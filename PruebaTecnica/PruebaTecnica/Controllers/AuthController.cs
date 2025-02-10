using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("token")]
        public IActionResult GetToken([FromBody] Usuario usuario)
        {
            var token = _authService.GenerateToken(usuario);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}