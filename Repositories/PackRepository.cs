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
    public class PackRepository : IPack
    {
        private readonly Pix4FunContext _ctx;

        public PackRepository()
        {
            _ctx = new Pix4FunContext();
        }

        public void Adicionar(Pack pack)
        {
            try
            {
                _ctx.Packs.Add(pack);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pack BuscarID(int id)
        {
            try
            {
                return _ctx.Packs.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Pack obj)
        {
            try
            {
                Pack temp = BuscarID(obj.IdPack);

                if (temp == null)
                    throw new Exception("Cupom não encontrado.");

                temp.TipoPack = obj.TipoPack;
                temp.Preco = obj.Preco;

                _ctx.Packs.Update(temp);
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
                Pack pack = BuscarID(id);
                if (pack == null)
                    throw new Exception("Pack não encontrado.");

                _ctx.Packs.Remove(pack);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pack> Listar()
        {
            try
            {
                List<Pack> packs = _ctx.Packs.Include("IdFotoNavigation").ToList();

                foreach (Pack _pack in packs)
                {
                    _pack.IdFotoNavigation.Pack = null;
                }

                return packs;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
