using FCG.Domain.Enums;

namespace FCG.Application.Requests.Jogos
{
    public sealed record CriarJogoRequest
    {
        public string Titulo { get; init; }
        public string Descricao { get; init; }
        public JogoGeneroEnum Genero { get; init; }
        public decimal Preco { get; init; }
        public decimal? PrecoPromocional { get; init; }
        public DateTime DataLancamento { get; init; }
    }
}