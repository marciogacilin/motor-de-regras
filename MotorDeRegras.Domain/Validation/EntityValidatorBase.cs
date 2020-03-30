using FluentValidation;
using System.Linq;

namespace MotorDeRegras.Domain.Validation
{
    public abstract class EntityValidatorBase
    {
        private string _messageError = string.Empty;

        protected bool _isValid;

        protected void Validate<T>(T entity, AbstractValidator<T> validationRules)
        {
            FluentValidation.Results.ValidationResult _result = validationRules.Validate(entity);

            _isValid = _result.IsValid;

            if (!_isValid)
                _messageError = _result.Errors.FirstOrDefault().ErrorMessage;            
        }

        public string MessageError()
        {
            return _messageError;
        }

        public abstract bool IsValid();

        public object Error()
        {
            return new { Message = _messageError };
        }
    }
}
