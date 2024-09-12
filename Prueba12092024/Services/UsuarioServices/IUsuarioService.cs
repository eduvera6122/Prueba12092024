using Prueba12092024.Models;
using Prueba12092024.Models.DTO;

namespace Prueba12092024.Services.UsuarioServices
{
    public interface IUsuarioService
    {
        LoginResponse login(Login login);
        EVeraUsuario crearUsuario(UsuarioDTO usuario);



    }
}
