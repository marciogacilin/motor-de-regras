using MotorDeRegras.Domain.Validation;
using System;

namespace MotorDeRegras.Domain.Entity
{
    public class Contexto : EntityValidatorBase
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public override bool IsValid()
        {
            var _validator = new ContextoValidator();

            Validate(this, _validator);

            return _isValid;
        }

        public Contexto(){}

        public Contexto(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public Contexto(string descricao)
        {
            Descricao = descricao;
        }
    }
}
