using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Interfaces
{
    interface IPerfilAcesso
    {
        List<Perfilacesso> Listar();
        Perfilacesso BuscarID(int id);
    }
}
