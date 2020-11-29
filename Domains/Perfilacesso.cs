using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Perfilacesso
    {
        public Perfilacesso()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdPerfilAcesso { get; set; }
        public string TipoPerfil { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
