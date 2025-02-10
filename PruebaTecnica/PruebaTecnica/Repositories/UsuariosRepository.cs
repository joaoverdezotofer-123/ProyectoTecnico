using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories
{
    public interface IUsuariosRepository
    {
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<string> AuthenticateAsync(string usuario, string pass);
    }

    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AppDbContext _context;

        public UsuariosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<string> AuthenticateAsync(string usuario, string pass)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == usuario && u.Pass == pass);
            if (user == null)
                return null;

            // Aquí deberías generar un token JWT
            return "token_generado";
        }
    }
}