using APIPix4Fun.Context;
using APIPix4Fun.Domains;
using APIPix4Fun.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Repositories
{
    public class PagamentoRepository : IPagamento
    {
        private readonly Pix4FunContext _ctx;

        public PagamentoRepository()
        {
            _ctx = new Pix4FunContext();
        }

        public void Adicionar(Pagamento obj)
        {
            try
            {
                _ctx.Pagamentos.Add(obj);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pagamento BuscarID(int id)
        {
            try
            {
                return _ctx.Pagamentos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Pagamento obj)
        {
            try
            {
                Pagamento temp = BuscarID(obj.IdPagamento);

                if (temp == null)
                    throw new Exception("Pagamento não encontrado.");

                temp.TipoPgto = obj.TipoPgto;
                temp.TipoEnvio = obj.TipoEnvio;
                temp.ValorTotal = obj.ValorTotal;
                temp.StatusPgto = obj.StatusPgto;

                _ctx.Pagamentos.Update(temp);
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
                Pagamento pagamento = BuscarID(id);
                if (pagamento == null)
                    throw new Exception("Pagamento não encontrado.");

                _ctx.Pagamentos.Remove(pagamento);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pagamento> Listar()
        {
            try
            {
                List<Pagamento> pagamentos = _ctx.Pagamentos.ToList();

                if (pagamentos == null)
                    throw new Exception("Não há pagamentos cadastrados.");

                return pagamentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
