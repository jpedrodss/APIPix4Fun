using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Interfaces
{
    interface IEndereco
    {
        void Adicionar(Endereco obj);
        void Excluir(int id);
        void Editar(Endereco obj);
        List<Endereco> Listar();
        Endereco BuscarID(int id);
    }
}
