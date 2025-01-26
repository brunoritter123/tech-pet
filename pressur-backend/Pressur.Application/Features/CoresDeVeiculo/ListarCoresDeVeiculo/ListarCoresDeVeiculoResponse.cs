using Pressur.Domain.Entities.Cadastros;

namespace Pressur.Application.Features.CoresDeVeiculo.ListarCoresDeVeiculo;
public class ListarCoresDeVeiculoResponse
{
    public required short Id { get; init; }
    public required string Nome { get; init; }

    public static implicit operator ListarCoresDeVeiculoResponse(CorDeVeiculo entity)
    {
        return new ListarCoresDeVeiculoResponse()
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
}