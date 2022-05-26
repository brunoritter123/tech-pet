using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace TechPet.Domain.Abstractions.Validacoes
{
    public interface IObjetoValidavel
    {
        bool Valido();
        bool Validar();
        IEnumerable<ValidationFailure> GetErros();
    }
}
