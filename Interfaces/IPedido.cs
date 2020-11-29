using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Interfaces
{
    interface IPedido
    {
        void Adicionar(Pedido obj);
        void Excluir(int id);
        void Editar(Pedido obj);
        List<Pedido> Listar();
        Pedido BuscarID(int id);
    }
}
