using Prueba12092024.Models;
using Prueba12092024.Models.DTO;

namespace Prueba12092024.Services.UsuarioServices
{
    public class UsuarioService : IUsuarioService
    {
        private EVERA_BDContext _context;

        public UsuarioService(EVERA_BDContext context)
        {
            _context = context;
        }

        public EVeraUsuario crearUsuario(UsuarioDTO usuario)
        {
          EVeraUsuario usuario1 = new EVeraUsuario
            {
                Username = usuario.Username,
                Nombres = usuario.Nombres,
                Email = usuario.Email,
                Estado = "A",
                Password = usuario.Password,
                Rol = usuario.Rol
            };

            _context.EVeraUsuarios.Add(usuario1);
            _context.SaveChanges();

            return usuario1;

        }

        public LoginResponse login(Login login)
        {
           EVeraUsuario usuario = _context.EVeraUsuarios.FirstOrDefault(u => u.Username == login.Usuario && u.Password == login.Clave);
          
            if (usuario != null)
            {
                return new LoginResponse
                {
                    IsValid = true,
                    Rol = usuario.Rol
                };
            }
            else
            {
                return new LoginResponse
                {
                    IsValid = false,
                    Rol = null
                };
            }
        }
    }
}
