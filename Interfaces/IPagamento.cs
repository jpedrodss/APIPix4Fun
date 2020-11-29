using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Interfaces
{
    interface IPagamento
    {
        void Adicionar(Pagamento pagamento);
        void Excluir(int id);
        void Editar(Pagamento pagamento);
        List<Pagamento> Listar();
        Pagamento BuscarID(int id);
    }
}
