using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TerceraRonda
    {
        public TerceraRonda()
        {
            Torneo = new HashSet<Torneo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Torneo> Torneo { get; set; }
    }
}
