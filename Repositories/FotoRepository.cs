using APIPix4Fun.Context;
using APIPix4Fun.Domains;
using APIPix4Fun.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Repositories
{
    public class FotoRepository : IFoto
    {
        private readonly Pix4FunContext _ctx;

        public FotoRepository()
        {
            _ctx = new Pix4FunContext();
        }

        public void Adicionar(Foto obj)
        {
            try
            {
                _ctx.Fotos.Add(obj);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Foto BuscarID(int id)
        {
            try
            {
                return _ctx.Fotos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Foto obj)
        {
            try
            {
                Foto temp = BuscarID(obj.IdFoto);

                if (temp == null)
                    throw new Exception("Cupom não encontrado.");

                temp.FraseFoto = obj.FraseFoto;

                _ctx.Fotos.Update(temp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                Foto foto = BuscarID(id);
                if (foto == null)
                    throw new Exception("Foto não encontrada.");

                _ctx.Fotos.Remove(foto);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Foto> Listar()
        {
            try
            {
                List<Foto> fotos = _ctx.Fotos.ToList();

                if (fotos == null)
                    throw new Exception("Não há cupons cadastrados");

                return fotos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
