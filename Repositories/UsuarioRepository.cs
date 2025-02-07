﻿using APIPix4Fun.Context;
using APIPix4Fun.Domains;
using APIPix4Fun.Interfaces;
using APIPix4Fun.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly Pix4FunContext _ctx;

        public UsuarioRepository()
        {
            _ctx = new Pix4FunContext();
        }

        public void Adicionar(Usuario obj)
        {
            try
            {
                obj.Senha = Crypto.Criptografar(obj.Senha, obj.Email.Substring(0, 4));

                _ctx.Usuarios.Add(obj);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario BuscarID(int id)
        {
            try
            {
                return _ctx.Usuarios.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Usuario obj)
        {
            try
            {
                Usuario temp = BuscarID(obj.IdUsuario);

                if (temp == null)
                    throw new Exception("Usuarios não encontrado.");

                temp.Nome = obj.Nome;
                temp.Email = obj.Email;
                temp.Senha = obj.Senha;
                temp.Telefone = obj.Telefone;
                temp.Cep = obj.Cep;
                temp.Rua = obj.Rua;
                temp.Numero = obj.Numero;
                temp.Complemento = obj.Complemento;

                temp.Senha = Crypto.Criptografar(temp.Senha, temp.Email.Substring(0, 4));

                _ctx.Usuarios.Update(temp);
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
                Usuario usuario = BuscarID(id);
                if (usuario == null)
                    throw new Exception("Usuarios não encontrado.");

                _ctx.Usuarios.Remove(usuario);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                List<Usuario> usuarios = _ctx.Usuarios.Include("IdPerfilAcessoNavigation").ToList();

                foreach (Usuario _usuario in usuarios)
                {
                    _usuario.IdPerfilAcessoNavigation.Usuario = null;
                }

                if (usuarios == null)
                    throw new Exception("Não há usuarios cadastrados.");

                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
