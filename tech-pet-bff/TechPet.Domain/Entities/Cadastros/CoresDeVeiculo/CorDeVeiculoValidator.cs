using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.Domain.Entities.Cadastros.CoresDeVeiculo
{
    public class CorDeVeiculoValidator : AbstractValidator<CorDeVeiculo>
    {
        public CorDeVeiculoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(CorDeVeiculo.TamanhoMaximoNome);
        }
    }
}
