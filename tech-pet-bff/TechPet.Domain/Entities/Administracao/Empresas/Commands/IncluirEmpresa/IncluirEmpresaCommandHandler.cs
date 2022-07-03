using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.Abstractions.Commands;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Empresas.Mappers;
using TechPet.Domain.Entities.Empresas.Repository;
using TechPet.Domain.Entities.Empresas.Results;

namespace TechPet.Domain.Entities.Empresas.Commands.IncluirEmpresa
{
    public class IncluirEmpresaCommandHandler : CommandHandlerInsert<IncluirEmpresaCommand, EmpresaResult?, Empresa, Guid>
    {
        public IncluirEmpresaCommandHandler(INotificacaoService notificacaoService, IEmpresaRepository empresaRepository)
            : base(notificacaoService, empresaRepository)
        {
        }

        protected override Empresa CommandToEntity(IncluirEmpresaCommand command)
        {
            return command.ToEmpresa();
        }

        protected override EmpresaResult? ResultRepositoryToResponse(Empresa? entity)
        {
            return entity?.ToEmpresaResult();
        }

        protected override bool ValidCommand(IncluirEmpresaCommand command)
        {
            return true;
        }
    }
}
