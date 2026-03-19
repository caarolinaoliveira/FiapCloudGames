using FCG.Domain.Entities;
using FCG.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using FCG.Domain.Notificacoes;

// FCG.Domain/Services/BaseDomainService.cs
namespace FCG.Domain.Services
{
    public abstract class BaseDomainService
    {
        private readonly INotificador _notificador;

        protected BaseDomainService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handler(new Notificacao(mensagem));
        }
    }
}