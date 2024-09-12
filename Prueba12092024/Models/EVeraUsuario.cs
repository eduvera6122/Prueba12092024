using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prueba12092024.Models
{
    public partial class EVeraUsuario
    {
        public EVeraUsuario()
        {
            EVeraSolicitudUsuarioCreadors = new HashSet<EVeraSolicitud>();
            EVeraSolicitudUsuarioGestors = new HashSet<EVeraSolicitud>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Estado { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<EVeraSolicitud> EVeraSolicitudUsuarioCreadors { get; set; }
        [JsonIgnore]
        public virtual ICollection<EVeraSolicitud> EVeraSolicitudUsuarioGestors { get; set; }
    }
}
