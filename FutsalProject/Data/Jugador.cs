using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Jugador
    {
        public Jugador()
        {
            Evento = new HashSet<Evento>();
            Jet = new HashSet<Jet>();
        }

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

        public ICollection<Evento> Evento { get; set; }
        public ICollection<Jet> Jet { get; set; }
    }
}
