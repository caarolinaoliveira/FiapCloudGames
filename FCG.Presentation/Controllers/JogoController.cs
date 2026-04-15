using FCG.Application.Requests.Jogos;
using FCG.Application.Services;
using FCG.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;

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

        [HttpGet]
        public async Task <IActionResult> ObterTodosJogos()
        {
            var response = await _jogoService.ObterTodosAsync();
            return Ok(response);
        }

        [HttpGet("{id: Guid}")]
        public async Task<IActionResult> ObterPorId(Guid titulo)
        {
            var response = await _jogoService.ObterJogoPorIdAsync(titulo);
            if (response == null)
                return NotFound();

            return Ok(response);
        }
        [HttpGet("{titulo}")]
        public async Task<IActionResult> ObterPorTitulo(string titulo)
        {
            var response = await _jogoService.ObterJogoPorTituloAsync(titulo);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarJogo(CriarJogoRequest request)
        {
            var response = await _jogoService.CriarJogoAsync(request);
            return CreatedAtAction(nameof(CadastrarJogo), new { id = response.Id }, response);
        }


        [HttpPut("{id: Guid}")]
        public async Task<IActionResult> AtualizarJogo(AtualizarJogoRequest request)
        {
            var response = await _jogoService.AtualizarJogoAsync(request);
            return Ok(response);
        }

        [HttpDelete("{titulo}")]
        public async Task<IActionResult> DeletarJogo(string titulo)
        {
            await _jogoService.DeletarJogoAsync(titulo);
            return NoContent();
        }
    }
}