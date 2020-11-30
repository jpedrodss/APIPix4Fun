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
        private readonly CupomRepository _cupomRepository;

        public CupomController()
        {
            _cupomRepository = new CupomRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cupoms = _cupomRepository.Listar();

                if (cupoms.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = cupoms.Count,
                    data = cupoms
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
                Cupom cupom = _cupomRepository.BuscarID(id);

                if (cupom == null)
                    return NotFound();

                return Ok(cupom);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post(Cupom cupom)
        {
            try
            {
                _cupomRepository.Adicionar(cupom);

                return Ok(cupom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Cupom cupom)
        {
            try
            {
                var cupomtemp = _cupomRepository.BuscarID(id);

                if (cupomtemp == null)
                    return NotFound();

                cupom.IdCupom = id;
                _cupomRepository.Editar(cupom);

                return Ok(cupom);
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
                _cupomRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
