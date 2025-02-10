using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories
{
    public interface IPersonasRepository
    {
        Task<IEnumerable<Persona>> GetPersonasAsync();
        Task<Persona> CreatePersonaAsync(Persona persona);
    }

    public class PersonasRepository : IPersonasRepository
    {
        private readonly AppDbContext _context;

        public PersonasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetPersonasAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }
    }
}