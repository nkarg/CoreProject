using System;
using System.Collections.Generic;

namespace Data
{
    public partial class RolUsuario
    {
        public RolUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Rol { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
