using FCG.Domain.Notificacoes;

namespace FCG.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacoes();
        List<Notificacao> ObterNotificacoes();
        void Handler(Notificacao notificacao);
    }
}