using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.Entities.Empresas.Results;

namespace TechPet.Domain.Entities.Empresas.Queries.BuscarEmpresa
{
    public class BuscarEmpresaQueryHandler : IRequestHandler<BuscarEmpresaQuery, EmpresaResult?>
    {
        public Task<EmpresaResult?> Handle(BuscarEmpresaQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
