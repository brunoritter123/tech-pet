using Pressur.Data.Abstractions;
using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Domain.Abstractions.Repository;
using Pressur.Identity.Entities;
using Pressur.Identity.Interfaces;

namespace Pressur.Application.Features.Usuarios.Registrar;

public class RegistrarUsuarioHandler : IRegistrarUsuarioHandler
{
    private readonly IIdentityService _identityService;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;

    public RegistrarUsuarioHandler(
        IIdentityService identityService,
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork, IJwtService jwtService) 
    {
        _identityService = identityService;
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public async Task<Result<RegistrarUsuarioResponse>> ExecutarAsync(RegistrarUsuarioCommand command, CancellationToken cancellationToken)
    {
        var resultRepository = await _usuarioRepository.AddAsync(command);
        if (!resultRepository.Sucesso) 
            return Result<RegistrarUsuarioResponse>.FromResultFail(resultRepository);

        var userIdentity = new User()
        {
            Email = command.Email,
            Nome = command.Nome,
            UserName = command.Login,
            CodigoEmpresa = _jwtService.GetCodigoEmpresaUserLogado() ?? throw new Exception("Usuario logado inválido")
        };

        var result = await _identityService.CriarUsuarioAsync(userIdentity, command.Senha);
        if (!result.Sucesso)
            Result<RegistrarUsuarioResponse>.FromResultFail(result);

        await _unitOfWork.CommitAsync();
        return resultRepository.ConvertResult(entity => (RegistrarUsuarioResponse)entity);
    }
}