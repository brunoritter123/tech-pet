using Microsoft.Extensions.Logging;
using Pressur.Application.Abstractions;
using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Domain.Abstractions.Paginacao;
using Pressur.Domain.Abstractions.Repository;

namespace Pressur.Application.Features.CoresDeVeiculo.ListarCoresDeVeiculo;

public class ListarCoresDeVeiculoHandler : IListarCoresDeVeiculoHandler
{
    private readonly ICorDeVeiculoRepository _corDeVeiculoRepository;

    public ListarCoresDeVeiculoHandler(ICorDeVeiculoRepository corDeVeiculoRepository)
    {
        _corDeVeiculoRepository = corDeVeiculoRepository;
    }

    public async Task<Result<Page<ListarCoresDeVeiculoResponse>>> ExecutarAsync(CancellationToken cancellationToken)
    {
        var resultRepository = await _corDeVeiculoRepository.ListarAsync(1, 100, cancellationToken);
        return resultRepository.ConvertResult(pageEntity =>
        {
            var responses = pageEntity.Itens.Select(entity => (ListarCoresDeVeiculoResponse)entity);
            return pageEntity.ConvertPage(responses);
        });
    }
}