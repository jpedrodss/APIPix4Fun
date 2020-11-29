using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Pagamento
    {
        public Pagamento()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdPagamento { get; set; }
        public int? IdUsuario { get; set; }
        public string TipoPgto { get; set; }
        public float? ValorTotal { get; set; }
        public string TipoEnvio { get; set; }
        public string StatusPgto { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
