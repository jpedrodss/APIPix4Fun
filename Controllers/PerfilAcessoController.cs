using APIPix4Fun.Domains;
using APIPix4Fun.Interfaces;
using APIPix4Fun.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPix4Fun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilAcessoController : ControllerBase
    {
        private readonly IPerfilAcesso _perfilAcessoRepository;

        public PerfilAcessoController()
        {
            _perfilAcessoRepository = new PerfilAcessoRepository();
        }

        /// <summary>
        /// Lista os perfilAcessos
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var perfilAcessos = _perfilAcessoRepository.Listar();

                if (perfilAcessos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = perfilAcessos.Count,
                    data = perfilAcessos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/PerfilAcessos"
                });
            }
        }

        /// <summary>
        /// Busca perfil de acesso por ID
        /// </summary>
        /// <param name="id">Id do Perfil</param>
        /// <returns>Perfil buscado</returns>
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
