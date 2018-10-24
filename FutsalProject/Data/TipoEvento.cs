using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            EventoNavigation = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Evento { get; set; }

        public ICollection<Evento> EventoNavigation { get; set; }
    }
}
