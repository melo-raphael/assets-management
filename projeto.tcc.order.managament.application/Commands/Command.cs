
using FluentValidation.Results;

namespace projeto.tcc.order.managament.application.Commands
{
    public abstract class Command
    {
        protected ValidationResult ValidationResult { get; set; }

        public ValidationResult GetValidationResult()
        {
            return ValidationResult;
        }

        public abstract bool IsValid();
    }
}
