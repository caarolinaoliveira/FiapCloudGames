using FCG.Domain.Entities;

namespace FCG.Domain.Interfaces
{
    public interface IBibliotecaRepository : IRepository<BibliotecaUsuarioEntity>
    {
        Task<IEnumerable<BibliotecaUsuarioEntity>> ObterPorUsuarioIdAsync(Guid usuarioId);
        Task<bool> UsuarioPossuiJogoAsync(Guid usuarioId, Guid jogoId);
    }
}