using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Cupom
    {
        public Cupom()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdCupom { get; set; }
        public float? ValorDesconto { get; set; }
        public DateTime? DataValidade { get; set; }
        public string PalavraChave { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
