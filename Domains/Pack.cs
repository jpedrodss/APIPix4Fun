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
        public int? IdFoto { get; set; }
        public string TipoPack { get; set; }
        public float? Preco { get; set; }

        public virtual Foto IdFotoNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
