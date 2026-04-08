using FCG.Application.Interfaces;       
using FCG.Application.Requests.Usuarios;
using FCG.Application.Responses.Usuarios;
using FCG.Domain.Entities;
using FCG.Domain.Interfaces;            

namespace FCG.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioResponse> CriarAsync(CriarUsuarioRequest request)
        {
            if (await _usuarioRepository.EmailJaCadastradoAsync(request.Email))
                throw new InvalidOperationException("E-mail já cadastrado.");

            var usuario = new UsuarioEntity
            {
                Nome           = request.Nome,
                Email          = request.Email,
                SenhaHash      = request.Senha,
                DataNascimento = request.DataNascimento,
                DataCriacao    = DateTime.UtcNow
            };

            await _usuarioRepository.AdicionarAsync(usuario);

            return new UsuarioResponse
            {
                Id             = usuario.Id,
                Nome           = usuario.Nome,
                Email          = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                DataCriacao    = usuario.DataCriacao
            };
        }
    }
}