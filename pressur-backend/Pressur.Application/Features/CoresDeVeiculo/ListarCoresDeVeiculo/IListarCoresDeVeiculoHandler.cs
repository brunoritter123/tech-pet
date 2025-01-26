using Pressur.Application.Abstractions;
using Pressur.Domain.Abstractions.Paginacao;

namespace Pressur.Application.Features.CoresDeVeiculo.ListarCoresDeVeiculo;

public interface IListarCoresDeVeiculoHandler : ICommandHandler<Page<ListarCoresDeVeiculoResponse>>;