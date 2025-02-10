using PruebaTecnica.Models;
using PruebaTecnica.Helpers;

namespace PruebaTecnica.Services
{
    public interface IAuthService
    {
        string GenerateToken(Usuario usuario);
    }

    public class AuthService : IAuthService
    {
        private readonly IJwtHelper _jwtHelper;

        public AuthService(IJwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        public string GenerateToken(Usuario usuario)
        {
            return _jwtHelper.GenerateToken(usuario);
        }
    }
}