using Connvert.Application.Interfaces;
using Connvert.Application.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Connvert.API.Controllers
{
    ///<Summary>
    /// NoticiasController
    ///</Summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiasController : ControllerBase
    {
        private readonly INoticiasAppService _noticiasAppService;

        ///<Summary>
        /// Construtor
        ///</Summary>
        public NoticiasController(INoticiasAppService noticiasAppService)
        {
            _noticiasAppService = noticiasAppService;

        }

        /// <summary>
        /// Inclui um novo registro a base de dados
        /// </summary>
        /// <param name="vmNoticia">Dados da Notícia</param>
        /// <response code="201">Retorna os dados da nova notícia.</response>  
        /// <response code="400">Formato da requisição é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [Route("incluir")]
        [ProducesResponseType(typeof(NoticiasModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IncluirAsync([FromBody] NoticiasModel vmNoticia)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _noticiasAppService.IncluirAsync(vmNoticia);

            return StatusCode((int)HttpStatusCode.Created, vmNoticia);

        }


        /// <summary>
        /// Edita uma noticia da base
        /// </summary>
        /// <param name="id">Indicador do registro</param>
        /// <param name="vmNoticia">Dados da Notícia.</param>
        /// <response code="201">Retorna os dados da Notícia.</response>  
        /// <response code="400">Formato da requisição é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut]
        [Route("editar")]
        [ProducesResponseType(typeof(NoticiasModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarAsync(string id, [FromBody] NoticiasModel vmNoticia)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _noticiasAppService.EditarAsync(id, vmNoticia);

            return StatusCode((int)HttpStatusCode.Created, vmNoticia);
        }


        /// <summary>
        /// Listar uma coleção noticia da base
        /// </summary>
        /// <param name="vmNoticia">Dados da Notícia.</param>
        /// <response code="201">Retorna os dados da Notícia.</response>  
        /// <response code="400">Formato da requisição é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [Route("listar")]
        [ProducesResponseType(typeof(IEnumerable<NoticiasModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarAsync([FromQuery] ConsultaNoticiasModel vmNoticia)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var noticias = _noticiasAppService.ListarAsync(vmNoticia);

            if (!noticias.Any())
                return NoContent();

            return Ok(noticias);
        }


        /// <summary>
        /// Deleta uma notíca da base
        /// </summary>
        /// <param name="id">Identificador da notícia.</param>
        /// <response code="204">notícia Deletada.</response>  
        /// <response code="404">Nenhum produto localizado</response>
        /// <response code="409">Produto já inativo na base.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete]
        [Route("inativar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Deletar(string id)
        {

            var existeNoticia = await _noticiasAppService.ExisteAsync(id);

            if (existeNoticia == null)
                return NotFound();

            _noticiasAppService.Remover(id);

            return NoContent();
        }
    }



}
