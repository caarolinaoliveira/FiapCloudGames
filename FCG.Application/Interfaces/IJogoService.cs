using FCG.Application.Requests.Jogos;
using FCG.Application.Responses.Jogos;

namespace  FCG.Application.Interfaces

{
    public interface IJogoService 
    {
        Task<List<JogoResponse>> ObterTodosAsync();
        Task<JogoResponse> ObterJogoPorTituloAsync(string titulo);
        Task<JogoResponse> ObterJogoPorIdAsync(Guid id);
        Task<JogoResponse> CriarJogoAsync(CriarJogoRequest jogo);
        Task<JogoResponse> AtualizarJogoAsync(AtualizarJogoRequest jogo);
        Task DeletarJogoAsync(string titulo);

    }
}