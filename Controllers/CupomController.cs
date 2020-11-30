using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPix4Fun.Domains;
using APIPix4Fun.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPix4Fun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private readonly CupomRepository _usuarioRepository;

        public CupomController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var packs = _usuarioRepository.Listar();

                if (packs.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = packs.Count,
                    data = packs
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
                Usuario categoria = _usuarioRepository.BuscarID(id);

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<UsuarioController>
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

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            try
            {
                var categoriaTemp = _usuarioRepository.BuscarID(id);

                if (categoriaTemp == null)
                    return NotFound();

                usuario.IdUsuario = id;
                _usuarioRepository.Editar(usuario);

                return Ok(usuario);
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
