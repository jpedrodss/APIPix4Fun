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
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoRepository _pagamentoRepository;

        public PagamentoController()
        {
            _pagamentoRepository = new PagamentoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pagamentos = _pagamentoRepository.Listar();

                if (pagamentos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = pagamentos.Count,
                    data = pagamentos
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
                Pagamento pagamento = _pagamentoRepository.BuscarID(id);

                if (pagamento == null)
                    return NotFound();

                return Ok(pagamento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post(Pagamento pagamento)
        {
            try
            {
                _pagamentoRepository.Adicionar(pagamento);

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pagamento pagamento)
        {
            try
            {
                var pagamentotemp = _pagamentoRepository.BuscarID(id);

                if (pagamentotemp == null)
                    return NotFound();

                pagamento.IdPagamento = id;
                _pagamentoRepository.Editar(pagamento);

                return Ok(pagamento);
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
                _pagamentoRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
