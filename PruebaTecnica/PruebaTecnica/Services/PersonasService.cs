using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;

namespace PruebaTecnica.Services
{
    public interface IPersonasService
    {
        Task<IEnumerable<Persona>> GetPersonasAsync();
        Task<Persona> CreatePersonaAsync(Persona persona);
    }

    public class PersonasService : IPersonasService
    {
        private readonly IPersonasRepository _personasRepository;

        public PersonasService(IPersonasRepository personasRepository)
        {
            _personasRepository = personasRepository;
        }

        public async Task<IEnumerable<Persona>> GetPersonasAsync()
        {
            return await _personasRepository.GetPersonasAsync();
        }

        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            return await _personasRepository.CreatePersonaAsync(persona);
        }
    }
}