using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Fotos
    {
        public Fotos()
        {
            Pack = new HashSet<Pack>();
        }

        public int IdFotos { get; set; }
        public string FraseFoto { get; set; }

        public virtual ICollection<Pack> Pack { get; set; }
    }
}
