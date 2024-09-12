using Microsoft.EntityFrameworkCore;
using Prueba12092024.Models;
using Prueba12092024.Models.DTO;

namespace Prueba12092024.Services.SolicitudServices
{
    public class SolicitudService : ISolicitudService
    {
        const string ESTADO_INGRESADA = "INGRESADA";
        const string ESTADO_EN_ATENCION = "EN ATENCION";
        const string ESTADO_ATENDIDA = "ATENDIDA";
        const string ESTADO_NO_RESUELTA = "NO RESUELTA";



        private EVERA_BDContext _context;

        public SolicitudService(EVERA_BDContext context)
        {
            _context = context;
        }

        public ResponseDTO ActualizarSolicitud(int id, SolicitudDTO solicitud)
        {
            EVeraSolicitud solicitud1 = _context.EVeraSolicituds.FirstOrDefault(u => u.Id == id);
            
            if(solicitud1 == null) {       
                return new ResponseDTO
                {
                    CodError = "1111",
                    MensajeError = "Solicitud no encontrada"
                };
            }


            solicitud1.Tipo = solicitud.Tipo;
            solicitud1.DescripcionSolicitud = solicitud.DescripcionSolicitud;
            solicitud1.Justificativo = solicitud.Justificativo;
            solicitud1.Estado = solicitud.Estado;
            solicitud1.DetalleGestion = solicitud.DetalleGestion;
            solicitud1.FechaIngreso = solicitud.FechaIngreso;
            solicitud1.FechaActualizacion = DateTime.Now;
            solicitud1.FechaGestion = null;
            solicitud1.UsuarioCreadorId = solicitud.UsuarioCreadorId;
            solicitud1.UsuarioGestorId = solicitud.UsuarioGestorId;

            _context.EVeraSolicituds.Update(solicitud1);

            int result = _context.SaveChanges();

            if (result > 0)
            {
                return new ResponseDTO
                {
                    CodError = "0000",
                    MensajeError = "Solicitud Actualizada Correctamente"
                };
            }
            else
            {
                return new ResponseDTO
                {
                    CodError = "1111",
                    MensajeError = "Error al actualizar la solicitud"
                };
            }
        }

        public EVeraSolicitud consultarSolicitud(int id)
        {
            EVeraSolicitud solicitud = _context.EVeraSolicituds.Include(p => p.UsuarioCreador).FirstOrDefault(s => s.Id == id);
            return solicitud;
        }

        public List<EVeraSolicitud> ConsultarSolicitudes(int? idUsuario,DateTime? fechaIngreso, string? estado)
        {
            if (idUsuario != null || fechaIngreso != null || estado != null)
            {
                List<EVeraSolicitud> solicitudes = _context.EVeraSolicituds.Where(s =>
                    (idUsuario == null || s.UsuarioCreadorId == idUsuario) &&
                    (fechaIngreso == null || s.FechaIngreso == fechaIngreso) &&
                    (estado == null || s.Estado == estado)
                ).ToList();

                return solicitudes;
            }
            else
            {
                List<EVeraSolicitud> solicitudes = _context.EVeraSolicituds.ToList();
                return solicitudes;
            }
        }


        public ResponseDTO CrearSolicitud(SolicitudDTO solicitud)
        {
            EVeraSolicitud nuevaSolicitud = new EVeraSolicitud();

            nuevaSolicitud.Tipo = solicitud.Tipo;
            nuevaSolicitud.DescripcionSolicitud = solicitud.DescripcionSolicitud;
            nuevaSolicitud.Justificativo = solicitud.Justificativo;
            nuevaSolicitud.Estado = ESTADO_INGRESADA;
            nuevaSolicitud.DetalleGestion = null;
            nuevaSolicitud.FechaIngreso = DateTime.Now;
            nuevaSolicitud.FechaActualizacion = solicitud.FechaActualizacion;
            nuevaSolicitud.FechaGestion = null;
            nuevaSolicitud.UsuarioCreadorId = solicitud.UsuarioCreadorId;

            _context.EVeraSolicituds.Add(nuevaSolicitud);

            int result = _context.SaveChanges();

            if(result > 0)
            {
                return new ResponseDTO
                {
                    CodError = "0000",
                    MensajeError = "Solicitud Ingresada Correctamente"
                };
            }
            else
            {
                return new ResponseDTO
                {
                    CodError = "1111",
                    MensajeError = "Error al ingresar la solicitud"
                };
            }
        }

        public ResponseDTO estadoSolicitud(int id, string estado)
        {
           EVeraSolicitud solicitud = _context.EVeraSolicituds.FirstOrDefault(s => s.Id == id);

            if (solicitud != null)
            {

                solicitud.Estado = estado.ToUpper();

                if(estado.ToUpper() == ESTADO_ATENDIDA || estado.ToUpper() == ESTADO_NO_RESUELTA)
                {
                    solicitud.FechaGestion = DateTime.Now;
                }
              
                _context.EVeraSolicituds.Update(solicitud);

                int result = _context.SaveChanges();

                if (result > 0)
                {
                    return new ResponseDTO
                    {
                        CodError = "0000",
                        MensajeError = "Estado de la solicitud actualizado correctamente"
                    };
                }
                else
                {
                    return new ResponseDTO
                    {
                        CodError = "1111",
                        MensajeError = "Error al actualizar el estado de la solicitud"
                    };
                }
            }
            else
            {
                return new ResponseDTO
                {
                    CodError = "1111",
                    MensajeError = "Solicitud no encontrada"
                };

            }
        }
    }
}
