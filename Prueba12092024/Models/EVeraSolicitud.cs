using System;
using System.Collections.Generic;

namespace Prueba12092024.Models
{
    public partial class EVeraSolicitud
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string DescripcionSolicitud { get; set; } = null!;
        public string? Justificativo { get; set; }
        public string Estado { get; set; } = null!;
        public string? DetalleGestion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime? FechaGestion { get; set; }
        public int UsuarioCreadorId { get; set; }
        public int? UsuarioGestorId { get; set; }

        public virtual EVeraUsuario UsuarioCreador { get; set; } = null!;
        public virtual EVeraUsuario? UsuarioGestor { get; set; }
    }
}
