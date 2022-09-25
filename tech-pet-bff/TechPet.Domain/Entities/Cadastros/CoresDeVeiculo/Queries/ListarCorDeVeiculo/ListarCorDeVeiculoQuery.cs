using MediatR;
using TechPet.Domain.Abstractions.Paginacao;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Results;

namespace TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Queries.ListarCorDeVeiculo
{
    public class ListarCorDeVeiculoQuery : IRequest<Page<CorDeVeiculoResult>>
    {
    }
}