using System;
using System.Collections.Generic;

namespace Data
{
    public partial class SegundaRonda
    {
        public SegundaRonda()
        {
            Torneo = new HashSet<Torneo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Torneo> Torneo { get; set; }
    }
}
