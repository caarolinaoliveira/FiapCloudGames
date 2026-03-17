using FCG.Domain.Entities;
using FCG.Domain.Entities.Validations;
using FCG.Domain.interfaces;
using FCG.Domain.Interfaces;


namespace  FCG.Domain.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly interfaces.IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository,
            INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario)
        {
            if (ExecutarValidacao(new UsuarioValidation(), usuario))
            {
                // var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(usuario.Email);
                // if (usuarioExistente != null)
                // {
                //     Notificar("Já existe um usuário com este email.");
                //     return null;
                // }
                // await _usuarioRepository.AdicionarAsync(usuario);
                // await _usuarioRepository.SaveChangesAsync();
                // return usuario;
            }
            throw new NotImplementedException();
        }
        public async Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario)
        {
            if (ExecutarValidacao(new UsuarioValidation(), usuario))
            {
                // var usuarioExistente = await _usuarioRepository.ObterPorIdAsync(usuario.Id);
                // if (usuarioExistente == null)
                // {
                //     Notificar("Usuário não encontrado.");
                //     return null;
                // }
                // usuarioExistente.Nome = usuario.Nome;
                // usuarioExistente.Email = usuario.Email;
                // usuarioExistente.SenhaHash = usuario.SenhaHash;
                // usuarioExistente.Role = usuario.Role;
                // usuarioExistente.DataNascimento = usuario.DataNascimento;
                // usuarioExistente.StatusConta = usuario.StatusConta;

                // await _usuarioRepository.AtualizarAsync(usuarioExistente);
                // await _usuarioRepository.SaveChangesAsync();
                // return usuarioExistente;
            }
            throw new NotImplementedException();
        }

        public async Task DeletarUsuarioAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}