using FCG.Domain.Interfaces;
using FCG.Domain.Entities;
using FCG.Application.Requests.Usuarios;
using FCG.Application.Interfaces;

namespace FCG.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(string identityUserId, CriarUsuarioRequest request)
        {
            var usuario = new UsuarioEntity
            {
                Nome = request.Nome,
                Email = request.Email,
                DataNascimento = request.DataNascimento!.Value,
                IdentityUserId = identityUserId
            };

            await _repository.AdicionarAsync(usuario);
        }

        public async Task<UsuarioEntity?> ObterPorIdentityIdAsync(string identityUserId)
            => await _repository.ObterPorIdentityIdAsync(identityUserId);
    }
}