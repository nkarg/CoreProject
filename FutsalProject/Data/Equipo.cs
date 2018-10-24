using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Equipo
    {
        public Equipo()
        {
            Evento = new HashSet<Evento>();
            Jet = new HashSet<Jet>();
        }

        public int Id { get; set; }
        public string NombreLargo { get; set; }
        public string NombreCorto { get; set; }
        public string EscudoUrl { get; set; }
        public string FechaAfiliacion { get; set; }
        public bool Borrado { get; set; }

        public ICollection<Evento> Evento { get; set; }
        public ICollection<Jet> Jet { get; set; }
    }
}
