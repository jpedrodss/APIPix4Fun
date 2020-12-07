using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Endereco = new HashSet<Endereco>();
            Pagamento = new HashSet<Pagamento>();
            Pedido = new HashSet<Pedido>();
        }

        public int IdUsuario { get; set; }
        public int? IdPerfilAcesso { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        public virtual Perfilacesso IdPerfilAcessoNavigation { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Pagamento> Pagamento { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
