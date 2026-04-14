using FCG.Application.Requests.Jogos;
using FCG.Application.Services;
using FCG.Application.Interfaces;
using FCG.Application.Requests.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;

namespace FCG.Presentation.Controllers
{
    [Route("api/criar-jogo")]
    public class JogoController : MainController
    {
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarJogo(CriarJogoRequest request)
        {
            var response = await _jogoService.CriarJogoAsync(request);
            return CreatedAtAction(nameof(CadastrarJogo), new { id = response.Id }, response);
        }
    }
}