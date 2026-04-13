using FCG.Domain.Entities;
using FCG.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using FCG.Domain.Notificacoes;

namespace FCG.Application.Services
{
    public abstract class BaseAppService
    {
        private readonly INotificador _notificador;

        protected BaseAppService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handler(new Notificacao(mensagem));
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }
    }
}