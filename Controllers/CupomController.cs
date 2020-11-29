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

        // GET: api/<CupomController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cupons = _cupomRepository.Listar();

                if (cupons.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = cupons.Count,
                    data = cupons
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoit Get/Cupom "
                });
            }
        }

        // GET api/<CupomController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CupomController>
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

        // PUT api/<CupomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CupomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
