using TechPet.Domain.Abstractions.Paginacao;
using TechPet.Domain.Entities.Cadastros.CoresDeVeiculo.Results;
using TechPet.UseCase.Abstractions;

namespace TechPet.UseCase.UseCases.CoresDeVeiculo.ListarCoresDeVeiculo
{
    public interface IListarCoresDeVeiculoUseCase : IUseCase<Page<CorDeVeiculoResult>>
    {
    }
}