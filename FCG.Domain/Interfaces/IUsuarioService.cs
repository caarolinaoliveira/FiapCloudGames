using FCG.Domain.Entities;

namespace FCG.Domain.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario);
        Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario);
        Task DeletarUsuarioAsync(Guid id);

    }
}