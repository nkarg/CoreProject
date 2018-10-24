using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public long Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string FotoUrl { get; set; }
        public string Email { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public int Rol { get; set; }
        public string FechaCreacion { get; set; }
        public bool Borrado { get; set; }

        public RolUsuario RolNavigation { get; set; }
    }
}
