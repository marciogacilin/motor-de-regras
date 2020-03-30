using FluentValidation;
using MotorDeRegras.Domain.Entity;

namespace MotorDeRegras.Domain.Validation
{
    public class ContextoValidator : AbstractValidator<Contexto>
    {
        public ContextoValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Informe a descrição do contexto");
        }
    }
}
