using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.Entities.Empresas.Results;

namespace TechPet.Domain.Entities.Empresas.Queries.ListarEmpresa
{
    public class ListarEmpresaQuery : IRequest<EmpresaResult?>
    {
    }
}
