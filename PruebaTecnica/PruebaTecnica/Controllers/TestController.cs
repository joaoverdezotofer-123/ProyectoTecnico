using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                // Verifica si la base de datos está accesible
                var persona = await _context.Personas.FirstOrDefaultAsync();
                if (persona != null)
                {
                    return Ok(new { message = "Conexión exitosa a la base de datos." });
                }
                return Ok(new { message = "Conexión exitosa, pero no se encontraron registros." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error de conexión a la base de datos.", error = ex.Message });
            }
        }
    }
}
