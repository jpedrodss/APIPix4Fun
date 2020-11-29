using APIPix4Fun.Context;
using APIPix4Fun.Domains;
using APIPix4Fun.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Repositories
{
    public class PedidoRepository : IPedido
    {
        private readonly Pix4FunContext _ctx;

        public PedidoRepository()
        {
            _ctx = new Pix4FunContext();
        }

        public void Adicionar(Pedido obj)
        {
            try
            {
                _ctx.Pedidos.Add(obj);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarID(int id)
        {
            try
            {
                return _ctx.Pedidos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Pedido obj)
        {
            try
            {
                Pedido temp = BuscarID(obj.IdPedido);

                if (temp == null)
                    throw new Exception("Pedido não encontrado.");

                temp.StatusPedido = obj.StatusPedido;

                _ctx.Pedidos.Update(temp);
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
                Pedido pedido = BuscarID(id);
                if (pedido == null)
                    throw new Exception("Pedido não encontrado.");

                _ctx.Pedidos.Remove(pedido);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                List<Pedido> pedidos = _ctx.Pedidos.ToList();

                if (pedidos == null)
                    throw new Exception("Não há pedidos cadastrados.");

                return pedidos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
