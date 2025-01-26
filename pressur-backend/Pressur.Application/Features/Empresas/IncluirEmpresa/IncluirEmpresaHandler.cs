using Microsoft.Extensions.Logging;
using Pressur.Data.Abstractions;
using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Domain.Abstractions.Repository;
using Pressur.Identity.Entities;
using Pressur.Identity.Interfaces;
using Empresa = Pressur.Domain.Entities.Administracao.Empresa;

namespace Pressur.Application.Features.Empresas.IncluirEmpresa;

public class IncluirEmpresaHandler : IIncluirEmpresaHandler
{
    private List<User> UsersCriados { get; set; }
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IIdentityService _identityService;
    private readonly ILogger<IncluirEmpresaHandler> _logger;

    public IncluirEmpresaHandler(
        IUnitOfWork unitOfWork,
        ILogger<IncluirEmpresaHandler> logger,
        IEmpresaRepository empresaRepository,
        IUsuarioRepository usuarioRepository,
        IIdentityService identityService)
    {
        _unitOfWork = unitOfWork;
        _empresaRepository = empresaRepository;
        _usuarioRepository = usuarioRepository;
        _identityService = identityService;
        _logger = logger;
        UsersCriados = [];
    }

    public async Task<Result<IncluirEmpresaResponse>> ExecutarAsync(IncluirEmpresaCommand command, CancellationToken cancellationToken)
    {
        var incluirUsuariosPressurResult = await IncluirUsuariosPressur(command);
        if (!incluirUsuariosPressurResult.Sucesso)
            return Result<IncluirEmpresaResponse>.FromResultFail(incluirUsuariosPressurResult);


        var tasks = command.Usuarios.Select(usuarioRequest => _usuarioRepository.AddAsync(usuarioRequest));
        
        var empresaResult = await _empresaRepository.AddAsync(new Empresa(
            codigoEmpresa: command.Codigo,
            nome: command.Nome,
            nomeFantasia: command.NomeFantasia,
            cnpj: command.Cnpj));
        
        await Task.WhenAll(tasks);

        if (!empresaResult.Sucesso)
            await DesfazerIncluirUsersIdentiy();

        var response = new Result<IncluirEmpresaResponse>(empresaResult.GetResultSucesso());

        await _unitOfWork.CommitAsync();
        return response;
        
    }

    private async Task<Result> IncluirUsuariosPressur(IncluirEmpresaCommand incluirEmpresaCommand)
    {
        foreach (var request in incluirEmpresaCommand.Usuarios)
        {
            var user = new User()
            {
                Email = request.Email,
                Nome = request.Nome,
                UserName = request.Email,
                CodigoEmpresa = incluirEmpresaCommand.Codigo,
            };
            var result = await _identityService.CriarUsuarioAsync(user, request.Senha);

            if (!result.Sucesso)
            {
                await DesfazerIncluirUsersIdentiy();
                return result;
            }
            UsersCriados.Add(user);
        }
        return new Result();
    }

    private async Task DesfazerIncluirUsersIdentiy()
    {
        foreach (var userIdentity in UsersCriados)
        {
            var result = await _identityService.ExcluirUsuarioAsync(userIdentity);

            if (!result.Sucesso)
            {
                _logger.LogError("Erro ao voltar excluir usuário, detalhes: {}", string.Join(',', result.GetErros()));
                throw new Exception("Erro interno.");
            }
        }
    }
}
