

using FCG.Domain.Notificacoes;

namespace FCG.Domain.Interfaces
{
    
   public interface INotificador
    {
         bool TemNotificacoes();
        List<Notificacoes.Notificacao> ObterNotificacoes();
        void Handler(Notificacao notificacao);
    }
}