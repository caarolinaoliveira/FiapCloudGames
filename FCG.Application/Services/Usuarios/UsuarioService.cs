using FCG.Application.Interfaces;       
using FCG.Application.Requests.Usuarios;
using FCG.Application.Responses.Usuarios;
using FCG.Domain.Entities;
using FCG.Domain.Interfaces;  
using FCG.Domain.Exceptions;          

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
                throw new ConflictException("E-mail já cadastrado.");

            var usuario = new UsuarioEntity
            {
                Nome           = request.Nome,
                Email          = request.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha),                
                DataNascimento = request.DataNascimento?.ToDateTime(TimeOnly.MinValue) ?? DateTime.MinValue,
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

        // TODO: substituir por Guid usuarioId após implementar JWT
        public async Task AtualizarSenhaAsync(AlterarSenhaRequest request)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado.");

            if (!BCrypt.Net.BCrypt.Verify(request.SenhaAtual, usuario.SenhaHash))
                throw new UnauthorizedException("Senha atual incorreta.");

            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(request.NovaSenha);
            await _usuarioRepository.AtualizarAsync(usuario);
        }

        // TODO: substituir por Guid usuarioId após implementar JWT  
        public async Task DeletarUsuarioAsync(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);

            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado.");

            await _usuarioRepository.DeletarAsync(usuario);
        }


    }
}