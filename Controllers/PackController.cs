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
    public class PackController : ControllerBase
    {
        private readonly PackRepository _packRepository;

        public PackController()
        {
            _packRepository = new PackRepository();
        }

        // GET: api/<PackController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var packs = _packRepository.Listar();

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

        // GET api/<PackController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PackController>
        [HttpPost]
        public IActionResult Post(Pack pack)
        {
            try
            {
                _packRepository.Adicionar(pack);

                return Ok(pack);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
