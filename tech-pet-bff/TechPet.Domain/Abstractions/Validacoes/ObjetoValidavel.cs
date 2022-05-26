using FluentValidation.Results;

namespace TechPet.Domain.Abstractions.Validacoes
{
    public abstract class ObjetoValidavel : IObjetoValidavel
    {

        private ValidationResult? ValidationResult { get; set; }

        protected void AddError(ValidationResult validationResult)
        {
            ValidationResult ??= new ValidationResult();
            validationResult.Errors.ToList().ForEach(falha => ValidationResult.Errors.Add(falha));
        }

        protected void AddError(string errorMessage, ValidationResult? validationResult = null)
        {
            ValidationResult ??= new ValidationResult();
            ValidationResult.Errors.Add(new ValidationFailure(null, errorMessage));
            validationResult?.Errors.ToList().ForEach(falha => validationResult.Errors.Add(falha));
        }

        protected void AddError(string mensagemErro, string nomePropriedade)
        {
            ValidationResult ??= new ValidationResult();
            ValidationResult.Errors.Add(new ValidationFailure(nomePropriedade, mensagemErro));
        }

        public abstract bool Validar();

        public virtual bool Valido() => ValidationResult?.IsValid ?? Validar();

        public virtual IEnumerable<ValidationFailure> GetErros() => ValidationResult?.Errors ?? new List<ValidationFailure>();
    }
}
