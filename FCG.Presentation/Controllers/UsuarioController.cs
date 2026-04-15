using FCG.Application.Interfaces;
using FCG.Application.Requests.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FCG.Presentation.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CriarUsuarioRequest request)
        {
            var response = await _usuarioService.CriarAsync(request);
            return CreatedAtAction(nameof(CadastrarUsuario), new { id = response.Id }, response);
        }

        [HttpPut("alterar-senha/{email}")]
        public async Task<IActionResult> AtualizarSenha([FromRoute] string email, [FromBody] AlterarSenhaRequest request)
        {
            await _usuarioService.AtualizarSenhaAsync(request);
            return NoContent();
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] string email)
        {
            await _usuarioService.DeletarUsuarioAsync(email);
            return NoContent();
        }
    }
}