using APIPix4Fun.Context;
using APIPix4Fun.Domains;
using APIPix4Fun.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Repositories
{
    public class PerfilAcessoRepository : IPerfilAcesso
    {
        private readonly Pix4FunContext _ctx;

        public PerfilAcessoRepository()
        {
            _ctx = new Pix4FunContext();
        }

        public Perfilacesso BuscarID(int id)
        {
            try
            {
                return _ctx.Perfilacesso.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Perfilacesso> Listar()
        {
            try
            {
                List<Perfilacesso> perfilacessos = _ctx.Perfilacesso.ToList();

                if (perfilacessos == null)
                    throw new Exception("Não há perfís de acesso cadastrados.");

                return perfilacessos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
