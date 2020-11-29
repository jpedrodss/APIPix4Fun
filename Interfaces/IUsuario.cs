using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Interfaces
{
    interface IUsuario
    {
        void Adicionar(Usuario obj);
        void Excluir(int id);
        void Editar(Usuario obj);
        List<Usuario> Listar();
        Usuario BuscarID(int id);
    }
}
