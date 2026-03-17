using FCG.Domain.Entities;
using FCG.Domain.Interfaces;
using FCG.Domain.Enums;

namespace FCG.Domain.interfaces

{
    public interface IJogoReposity : IRepository<JogoEntity>
    {
            Task<List<JogoEntity>> ObterPorGeneroAsync(JogoGeneroEnum genero);
            Task<List<JogoEntity>> ObterPorStatusAsync(JogoStatusEnum status);
            Task<List<JogoEntity>> ObterPorPrecoAsync(decimal precoMinimo, decimal precoMaximo);
            Task<List<JogoEntity>> ObterPorDataLancamentoAsync(DateTime dataInicio, DateTime dataFim);
    }
}