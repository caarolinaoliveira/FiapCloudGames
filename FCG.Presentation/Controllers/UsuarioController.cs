using FCG.Application.Interfaces;
using FCG.Application.Requests.Usuarios;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CriarUsuarioRequest request)
        {
            var response = await _usuarioService.CriarAsync(request);
            return CreatedAtAction(nameof(CadastrarUsuario), new { id = response.Id }, response);
        }
    }
}