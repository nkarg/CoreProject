using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Estado
    {
        public Estado()
        {
            Jet = new HashSet<Jet>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Jet> Jet { get; set; }
    }
}
