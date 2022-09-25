using MediatR;
using Microsoft.Extensions.Logging;
using Prometheus;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Abstractions.Paginacao;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Queries.ListarCorDeVeiculo;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Results;
using TechPet.Identity.Interfaces;
using TechPet.UseCase.Abstractions;

namespace TechPet.UseCase.UseCases.CoresDeVeiculo.ListarCoresDeVeiculo
{
    public class ListarCoresDeVeiculoUseCase : UseCaseQuery<Page<CorDeVeiculoResult>>, IListarCoresDeVeiculoUseCase
    {
        private readonly IMediator _mediator;

        public ListarCoresDeVeiculoUseCase(INotificacaoService notificacaoService, ILogger<UseCaseQuery<Page<CorDeVeiculoResult>>> logger, IMediator mediator)
            : base(notificacaoService, logger)
        {
            _mediator = mediator;
        }

        protected override async Task<Page<CorDeVeiculoResult>?> AoExecutarAsync()
            => await _mediator.Send(new ListarCorDeVeiculoQuery());
    }
}