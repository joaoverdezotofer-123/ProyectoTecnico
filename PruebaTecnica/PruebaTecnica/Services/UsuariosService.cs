using System.Threading.Tasks;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;

namespace PruebaTecnica.Services
{
    public interface IUsuariosService
    {
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<string> AuthenticateAsync(string usuario, string pass);
    }

    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            return await _usuariosRepository.CreateUsuarioAsync(usuario);
        }

        public async Task<string> AuthenticateAsync(string usuario, string pass)
        {
            return await _usuariosRepository.AuthenticateAsync(usuario, pass);
        }
    }
}