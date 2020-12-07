using APIPix4Fun.Domains;
using APIPix4Fun.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoRepository _enderecoRepository;

        public EnderecoController()
        {
            _enderecoRepository = new EnderecoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var enderecos = _enderecoRepository.Listar();

                if (enderecos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = enderecos.Count,
                    data = enderecos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoit Get/Pack "
                });
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Endereco endereco = _enderecoRepository.BuscarID(id);

                if (endereco == null)
                    return NotFound();

                return Ok(endereco);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post(Endereco endereco)
        {
            try
            {
                _enderecoRepository.Adicionar(endereco);

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Endereco endereco)
        {
            try
            {
                var enderecotemp = _enderecoRepository.BuscarID(id);

                if (enderecotemp == null)
                    return NotFound();

                endereco.IdEndereco = id;
                _enderecoRepository.Editar(endereco);

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _enderecoRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
