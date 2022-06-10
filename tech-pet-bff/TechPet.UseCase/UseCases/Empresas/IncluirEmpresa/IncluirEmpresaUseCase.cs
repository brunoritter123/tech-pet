using MediatR;
using Microsoft.Extensions.Logging;
using System;
using TechPet.Data.Abstractions;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Empresas.Commands.IncluirEmpresa;
using TechPet.Domain.Entities.Empresas.Results;
using TechPet.UseCase.Abstractions;

namespace TechPet.UseCase.UseCases.Empresas.IncluirEmpresa
{
    public class IncluirEmpresaUseCase : UseCaseSimpleCommand<IncluirEmpresaCommand, EmpresaResult?>, IIncluirEmpresaUseCase
    {
        public IncluirEmpresaUseCase(INotificacaoService notificacaoService, IMediator mediator, IUnitOfWork unitOfWork, ILogger<UseCaseCommand<IncluirEmpresaCommand, EmpresaResult?>> logger) : base(notificacaoService, mediator, unitOfWork, logger)
        {
        }
    }
}
