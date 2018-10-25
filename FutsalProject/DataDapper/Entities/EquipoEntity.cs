using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDapper.Entities
{
    public class EquipoEntity
    {
        public int Id { get; set; }
        public string NombreLargo { get; set; }
        public string NombreCorto { get; set; }
        public string EscudoUrl { get; set; }
        public string FechaAfiliacion { get; set; }
        public bool Borrado { get; set; }
    }
}
