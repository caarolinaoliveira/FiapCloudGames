using FCG.Domain.Entities;

namespace FCG.Domain.Interfaces
{
    public interface IJogoService : IDisposable
    {
        Task<JogoEntity> CriarJogoAsync(JogoEntity jogo);
        Task<JogoEntity> AtualizarJogoAsync(JogoEntity jogo);
        Task DeletarJogoAsync(Guid id);

    }
}