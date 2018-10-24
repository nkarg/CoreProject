using System;
using System.Collections.Generic;

namespace Data
{
    public partial class PrimeraRonda
    {
        public PrimeraRonda()
        {
            Torneo = new HashSet<Torneo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Torneo> Torneo { get; set; }
    }
}
