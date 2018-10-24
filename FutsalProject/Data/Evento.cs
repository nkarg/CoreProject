using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Evento
    {
        public int Id { get; set; }
        public int IdTorneo { get; set; }
        public int IdPartido { get; set; }
        public int IdEquipo { get; set; }
        public int IdJugador { get; set; }
        public int TipoEvento { get; set; }
        public int Tiempo { get; set; }
        public string Minuto { get; set; }

        public Equipo IdEquipoNavigation { get; set; }
        public Jugador IdJugadorNavigation { get; set; }
        public Partido IdPartidoNavigation { get; set; }
        public Torneo IdTorneoNavigation { get; set; }
        public TipoEvento TipoEventoNavigation { get; set; }
    }
}
