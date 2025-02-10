using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Models;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonasService _personasService;

        public PersonasController(IPersonasService personasService)
        {
            _personasService = personasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return Ok(await _personasService.GetPersonasAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> CreatePersona(Persona persona)
        {
            var createdPersona = await _personasService.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersonas), new { id = createdPersona.Identificador }, createdPersona);
        }
    }
}