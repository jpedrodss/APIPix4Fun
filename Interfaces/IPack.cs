using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Interfaces
{
    interface IPack
    {
        void Adicionar(Pack obj);
        void Excluir(int id);
        void Editar(Pack obj);
        List<Pack> Listar();
        Pack BuscarID(int id);
    }
}
