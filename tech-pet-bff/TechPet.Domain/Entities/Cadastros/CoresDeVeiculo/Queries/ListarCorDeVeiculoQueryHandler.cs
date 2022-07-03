using MediatR;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Repository;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Results;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Mappers;
using TechPet.Domain.Abstractions.Paginacao;

namespace TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Commads
{
    public class ListarCorDeVeiculoQueryHandler : IRequestHandler<ListarCorDeVeiculoQuery, Page<CorDeVeiculoResult>>
    {
        private readonly ICorDeVeiculoRepository _repository;
        public ListarCorDeVeiculoQueryHandler(ICorDeVeiculoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Page<CorDeVeiculoResult>> Handle(ListarCorDeVeiculoQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.ListarAsync(cancellationToken: cancellationToken);
            var results = entities.Items.Select(entity => entity.ToCorDeVeiculoResult());
            return new Page<CorDeVeiculoResult>(results, entities.HasNext);
        }
    }
}