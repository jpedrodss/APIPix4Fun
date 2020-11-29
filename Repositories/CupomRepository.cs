using APIPix4Fun.Context;
using APIPix4Fun.Domains;
using APIPix4Fun.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Repositories
{
    public class CupomRepository : ICupom
    {
        private readonly Pix4FunContext _ctx;

        public CupomRepository()
        {
            _ctx = new Pix4FunContext();
        }

        public void Adicionar(Cupom obj)
        {
            try
            {
                _ctx.Cupons.Add(obj);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cupom BuscarID(int id)
        {
            try
            {
                return _ctx.Cupons.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Cupom obj)
        {
            try
            {
                Cupom temp = BuscarID(obj.IdCupom);

                if (temp == null)
                    throw new Exception("Cupom não encontrado.");

                temp.PalavraChave = obj.PalavraChave;
                temp.DataValidade = obj.DataValidade;
                temp.ValorDesconto = obj.ValorDesconto;

                _ctx.Cupons.Update(temp);
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
                Cupom cupom = BuscarID(id);
                if (cupom == null)
                    throw new Exception("Cupom não encontrado.");

                _ctx.Cupons.Remove(cupom);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cupom> Listar()
        {
            try
            {
                List<Cupom> cupoms = _ctx.Cupons.ToList();

                if (cupoms == null)
                    throw new Exception("Não há cupons cadastrados");

                return cupoms;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
