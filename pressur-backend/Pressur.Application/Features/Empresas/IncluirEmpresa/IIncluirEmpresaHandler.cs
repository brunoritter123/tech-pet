using Pressur.Application.Abstractions;

namespace Pressur.Application.Features.Empresas.IncluirEmpresa;
public interface IIncluirEmpresaHandler : ICommandHandler<IncluirEmpresaCommand, IncluirEmpresaResponse>;