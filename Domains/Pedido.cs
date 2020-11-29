using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPack { get; set; }
        public int? IdCupom { get; set; }
        public int? IdPagamento { get; set; }

        public virtual Cupom IdCupomNavigation { get; set; }
        public virtual Pack IdPackNavigation { get; set; }
        public virtual Pagamento IdPagamentoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
