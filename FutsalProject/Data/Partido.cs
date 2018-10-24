using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Partido
    {
        public Partido()
        {
            Evento = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public int IdTorneo { get; set; }
        public int Ronda { get; set; }
        public int? Fase { get; set; }
        public int? Llave { get; set; }
        public int FechaNumero { get; set; }
        public int IdEquipoLocal { get; set; }
        public int IdEquipoVisitante { get; set; }
        public bool Jugado { get; set; }
        public string FechaJugado { get; set; }
        public int? GolesLocal { get; set; }
        public int? GolesVisitante { get; set; }

        public Torneo IdTorneoNavigation { get; set; }
        public ICollection<Evento> Evento { get; set; }
    }
}
