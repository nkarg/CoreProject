using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class JugadorEntity
    {
        public int Id { get; set; }
        public long Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelefonoEmergencia { get; set; }
        public string FotoUrl { get; set; }
        public int IdPieHabil { get; set; }
        public string FechaAfiliacion { get; set; }
        public bool Borrado { get; set; }
    }
}
