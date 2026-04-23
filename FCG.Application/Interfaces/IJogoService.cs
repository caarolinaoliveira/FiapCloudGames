using FCG.Application.Requests.Jogos;
using FCG.Application.Responses.Jogos;

namespace  FCG.Application.Interfaces

{
    public interface IJogoService 
    {
        Task<List<JogoResponse>> ObterTodosAsync();
        Task<List<JogoResponse>> ObterJogoPorTituloAsync(string titulo);
        Task<JogoResponse> ObterJogoPorIdAsync(Guid id);
        Task<JogoResponse> CriarJogoAsync(CriarJogoRequest jogo);
        Task<JogoResponse> AtualizarJogoAsync(Guid id, AtualizarJogoRequest jogo);
        Task DeletarJogoAsync(Guid id);

    }
}