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
    public class FotoController : ControllerBase
    {
        private readonly FotoRepository _fotoRepository;

        public FotoController()
        {
            _fotoRepository = new FotoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var fotos = _fotoRepository.Listar();

                if (fotos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = fotos.Count,
                    data = fotos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoit Get/Foto "
                });
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Foto foto = _fotoRepository.BuscarID(id);

                if (foto == null)
                    return NotFound();

                return Ok(foto);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post(Foto foto)
        {
            try
            {
                _fotoRepository.Adicionar(foto);

                return Ok(foto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Foto foto)
        {
            try
            {
                var fototemp = _fotoRepository.BuscarID(id);

                if (fototemp == null)
                    return NotFound();

                foto.IdFoto = id;
                _fotoRepository.Editar(foto);

                return Ok(foto);
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
                _fotoRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
