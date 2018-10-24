using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class TorneoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPrimeraRonda { get; set; }
        public int? IdSegundaRonda { get; set; }
        public int? IdTerceraRonda { get; set; }
        public int? TiempoDeJuego { get; set; }
        public string FechaCreacion { get; set; }
        public bool Borrado { get; set; }

    }
}
