using FCG.Domain.Entities;
using FCG.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using FCG.Domain.Notificacoes;

namespace  FCG.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) 
            where TV : AbstractValidator<TE> 
            where TE : Entity
        {
            var validator = Activator.CreateInstance<TV>();
            var validationResult = validator.Validate(entidade);
            if (validationResult.IsValid) return true;

            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
            return false;
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