using FluentValidation;

namespace FCG.Domain.Entities.Validations
{
    public class UsuarioValidation : AbstractValidator<UsuarioEntity>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve conter entre 2 e 100 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser válido.");

            RuleFor(x => x.SenhaHash)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(8).WithMessage("Mínimo de 8 caracteres.")
                .Matches("[A-Z]").WithMessage("Deve conter ao menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("Deve conter ao menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("Deve conter ao menos um número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Deve conter ao menos um caractere especial.");

            RuleFor(u => u.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser no passado.");
        }
    }
}