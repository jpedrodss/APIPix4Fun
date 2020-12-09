using APIPix4Fun.Domains;
using APIPix4Fun.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Controllers
{
    public class PerfilAcessoController : Controller
    {
        private readonly PerfilAcessoRepository _perfilAcessoRepository;

        public PerfilAcessoController()
        {
            _perfilAcessoRepository = new PerfilAcessoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var perfis = _perfilAcessoRepository.Listar();

                if (perfis.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = perfis.Count,
                    data = perfis
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
                Perfilacesso perfilAcesso = _perfilAcessoRepository.BuscarID(id);

                if (perfilAcesso == null)
                    return NotFound();

                return Ok(perfilAcesso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
