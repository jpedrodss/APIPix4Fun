﻿using System;
using APIPix4Fun.Domains;
using APIPix4Fun.Interfaces;
using APIPix4Fun.Repositories;
using APIPix4Fun.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPix4Fun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _usuarioRepository.Listar();

                if (usuarios.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = usuarios.Count,
                    data = usuarios
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/Usuarios"
                });
            }
        }

        /// <summary>
        /// Busca usuário por ID
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <returns>Usuário buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarID(id);

                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um usuário a base de dados
        /// </summary>
        /// <param name="usuario">Usuario a ser adicionado</param>
        /// <returns>Usuario adicionado</returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {

                _usuarioRepository.Adicionar(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="id">ID para buscar usuario</param>
        /// <param name="usuario">Objeto para pegar informações do usuário</param>
        /// <returns>Alterações feitas</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            try
            {
                var usuarioTemp = _usuarioRepository.BuscarID(id);

                if (usuarioTemp == null)
                    return NotFound();

                usuario.IdUsuario = id;
                _usuarioRepository.Editar(usuario);

                usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="id">ID do usuario para ser exlcuido</param>
        /// <returns>Status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
