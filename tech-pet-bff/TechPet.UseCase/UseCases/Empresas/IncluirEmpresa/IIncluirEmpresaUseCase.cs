using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.Entities.Empresas.Commands.IncluirEmpresa;
using TechPet.Domain.Entities.Empresas.Results;
using TechPet.UseCase.Abstractions;

namespace TechPet.UseCase.UseCases.Empresas.IncluirEmpresa
{
    public interface IIncluirEmpresaUseCase: IUseCase<IncluirEmpresaRequest, EmpresaResult?>
    {
    }
}
