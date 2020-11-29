using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Interfaces
{
    interface ICupom
    {
        void Adicionar(Cupom obj);
        void Excluir(int id);
        void Editar(Cupom obj);
        List<Cupom> Listar();
        Cupom BuscarID(int id);
    }
}
