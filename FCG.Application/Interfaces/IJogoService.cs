using FCG.Application.Requests.Jogos;
using FCG.Application.Responses.Jogos;

namespace  FCG.Application.Interfaces

{
    public interface IJogoService 
    {
        Task<JogoResponse> CriarJogoAsync(CriarJogoRequest jogo);
        Task<JogoResponse> AtualizarJogoAsync(AtualizarJogoRequest jogo);
        Task DeletarJogoAsync(string titulo);

    }
}