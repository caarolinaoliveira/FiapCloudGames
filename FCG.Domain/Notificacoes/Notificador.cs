
using FCG.Domain.Interfaces;

namespace  FCG.Domain.Notificacoes
{
    internal class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes = new List<Notificacao>();

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }
        public void Handler(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacoes()
        {
            return _notificacoes.Any();
        }
    }
    
}