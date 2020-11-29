using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Interfaces
{
    interface IFoto
    {
        void Adicionar(Foto obj);
        void Excluir(int id);
        void Editar(Foto obj);
        List<Foto> Listar();
        Foto BuscarID(int id);
    }
}
