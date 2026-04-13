using FCG.Application.Requests.Jogos;
using FluentValidation;

namespace FCG.Application.Validators.Jogos
{
    public class AtualizarJogoValidator : AbstractValidator<AtualizarJogoRequest>
    {
        public AtualizarJogoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Título é obrigatório.")
                .MinimumLength(2).WithMessage("Título deve ter ao menos 2 caracteres.")
                .MaximumLength(200).WithMessage("Título deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Descrição é obrigatória.")
                .MaximumLength(1000).WithMessage("Descrição deve ter no máximo 1000 caracteres.");

            RuleFor(x => x.Genero)
                .IsInEnum().WithMessage("Gênero inválido.");

            RuleFor(x => x.Preco)
                .GreaterThanOrEqualTo(0).WithMessage("Preço não pode ser negativo.");

            RuleFor(x => x.PrecoPromocional)
                .GreaterThanOrEqualTo(0).WithMessage("Preço promocional não pode ser negativo.")
                .LessThan(x => x.Preco).WithMessage("Preço promocional deve ser menor que o preço original.")
                .When(x => x.PrecoPromocional.HasValue);

            RuleFor(x => x.DataLancamento)
                .NotEmpty().WithMessage("Data de lançamento é obrigatória.");
        }
    }
}