using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Torneo
    {
        public Torneo()
        {
            Evento = new HashSet<Evento>();
            Jet = new HashSet<Jet>();
            Partido = new HashSet<Partido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPrimeraRonda { get; set; }
        public int? IdSegundaRonda { get; set; }
        public int? IdTerceraRonda { get; set; }
        public int? TiempoDeJuego { get; set; }
        public string FechaCreacion { get; set; }
        public bool Borrado { get; set; }

        public PrimeraRonda IdPrimeraRondaNavigation { get; set; }
        public SegundaRonda IdSegundaRondaNavigation { get; set; }
        public TerceraRonda IdTerceraRondaNavigation { get; set; }
        public ICollection<Evento> Evento { get; set; }
        public ICollection<Jet> Jet { get; set; }
        public ICollection<Partido> Partido { get; set; }
    }
}
