using APIPix4Fun.Context;
using APIPix4Fun.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Repositories
{
    public class EnderecoRepository
    {
        private readonly Pix4FunContext _ctx;

        public EnderecoRepository()
        {
            _ctx = new Pix4FunContext();
        }

        public void Adicionar(Endereco obj)
        {
            try
            {
                _ctx.Enderecos.Add(obj);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Endereco BuscarID(int id)
        {
            try
            {
                return _ctx.Enderecos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Endereco obj)
        {
            try
            {
                Endereco temp = BuscarID(obj.IdEndereco);

                if (temp == null)
                    throw new Exception("Cupom não encontrado.");

                temp.Rua = obj.Rua;
                temp.Bairro = obj.Bairro;
                temp.Cidade = obj.Cidade;
                temp.Uf = obj.Uf;
                temp.Cep = obj.Cep;
                temp.Numero = obj.Numero;
                temp.Complemento = obj.Complemento;

                _ctx.Enderecos.Update(temp);
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
                Endereco endereco = BuscarID(id);
                if (endereco == null)
                    throw new Exception("Endereco não encontrada.");

                _ctx.Enderecos.Remove(endereco);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Endereco> Listar()
        {
            try
            {
                List<Endereco> enderecos = _ctx.Enderecos.ToList();

                if (enderecos == null)
                    throw new Exception("Não há cupons cadastrados");

                return enderecos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
