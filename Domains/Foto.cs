using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Foto
    {
        public Foto()
        {
            Pack = new HashSet<Pack>();
        }

        public int IdFoto { get; set; }
        public string UrlImagem { get; set; }
        public string FraseFoto { get; set; }

        public virtual ICollection<Pack> Pack { get; set; }
    }
}
