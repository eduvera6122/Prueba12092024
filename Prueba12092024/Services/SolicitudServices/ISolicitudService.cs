using Prueba12092024.Models;
using Prueba12092024.Models.DTO;

namespace Prueba12092024.Services.SolicitudServices
{
    public interface ISolicitudService
    {

        List<EVeraSolicitud> ConsultarSolicitudes(int? idUsuario , DateTime? fechaIngreso , string? estado);

        ResponseDTO CrearSolicitud(SolicitudDTO solicitud);

        ResponseDTO ActualizarSolicitud(int id, SolicitudDTO solicitud);

        ResponseDTO estadoSolicitud(int id , string estado);
        
        EVeraSolicitud consultarSolicitud(int id);



    }
}
