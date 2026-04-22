using System.Net;
using FCG.Application.Interfaces;
using FCG.Application.Requests.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FCG.Presentation.Controllers
{
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("api/usuarios/registrar")]
        public async Task<IActionResult> Registrar([FromBody] CriarUsuarioRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true
            };

            var response = await _userManager.CreateAsync(user, request.Senha);

            if (!response.Succeeded)
                return BadRequest(response.Errors);

            await _userManager.AddToRoleAsync(user, "Usuario");

            await _signInManager.SignInAsync(user, isPersistent: false);

            var roles = await _userManager.GetRolesAsync(user);

            var token = _tokenService.GerarToken(user.Email!, roles);

            return Ok(token);
        }

        [HttpPost("api/usuarios/login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _signInManager.PasswordSignInAsync(
                request.Email,
                request.Senha,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (!response.Succeeded)
                return Unauthorized("Usuário ou senha inválidos.");

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return Unauthorized();

            var roles = await _userManager.GetRolesAsync(user);

            var token = _tokenService.GerarToken(user.Email!, roles);

            return Ok(token);
        }
    }
}
