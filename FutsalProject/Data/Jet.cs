using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Jet
    {
        public int Id { get; set; }
        public int? IdJugador { get; set; }
        public int? IdEquipo { get; set; }
        public int? IdTorneo { get; set; }
        public int? Goles { get; set; }
        public int? Faltas { get; set; }
        public int? AmarillasAcumuladas { get; set; }
        public int? AmarillasTotales { get; set; }
        public int? AzulesAcumuladas { get; set; }
        public int? AzulesTotales { get; set; }
        public int Estado { get; set; }

        public Estado EstadoNavigation { get; set; }
        public Equipo IdEquipoNavigation { get; set; }
        public Jugador IdJugadorNavigation { get; set; }
        public Torneo IdTorneoNavigation { get; set; }
    }
}
