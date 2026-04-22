using FCG.Application.Requests.Jogos;
using FCG.Application.Responses.Jogos;
using FCG.Application.Services;
using FCG.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;


namespace FCG.Presentation.Controllers
{
    [Route("api/jogos")]
    public class JogoController : MainController
    {
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }


        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(List<JogoResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task <IActionResult> ObterTodosJogos()
        {
            var response = await _jogoService.ObterTodosAsync();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(JogoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorId(Guid titulo)
        {
            var response = await _jogoService.ObterJogoPorIdAsync(titulo);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{titulo}")]
        [ProducesResponseType(typeof(JogoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorTitulo(string titulo)
        {
            var response = await _jogoService.ObterJogoPorTituloAsync(titulo);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("cadastrar")]
        [ProducesResponseType(typeof(JogoResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CadastrarJogo(CriarJogoRequest request)
        {
            var response = await _jogoService.CriarJogoAsync(request);
            return CreatedAtAction(nameof(CadastrarJogo), new { id = response.Id }, response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(JogoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AtualizarJogo(AtualizarJogoRequest request)
        {
            var response = await _jogoService.AtualizarJogoAsync(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{titulo}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound) ]
        public async Task<IActionResult> DeletarJogo(string titulo)
        {
            if (string.IsNullOrEmpty(titulo))
                return BadRequest("O título do jogo é obrigatório.");
            
            await _jogoService.DeletarJogoAsync(titulo);
            return NoContent();
        }
    }
}