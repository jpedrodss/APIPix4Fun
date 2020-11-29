using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Pack
    {
        public Pack()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdPack { get; set; }
        public int? IdFotos { get; set; }
        public string TipoPack { get; set; }
        public float? Preco { get; set; }

        public virtual Fotos IdFotosNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
