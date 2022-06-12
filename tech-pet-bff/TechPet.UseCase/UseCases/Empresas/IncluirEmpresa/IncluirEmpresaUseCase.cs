using MediatR;
using Microsoft.Extensions.Logging;
using TechPet.Data.Abstractions;
using TechPet.Data.Context;
using TechPet.Domain.Abstractions.Notifications;
using TechPet.Domain.Entities.Empresas.Commands.IncluirEmpresa;
using TechPet.Domain.Entities.Empresas.Results;
using TechPet.Domain.Entities.Usuarios.Commands.RegistrarUsuario;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;
using TechPet.UseCase.Abstractions;
using TechPet.Application.Extensions.Identity.NotifyIdentityErrors;
using TechPet.Application.Commands.IncluirUsers;
using TechPet.Application.Commands.CriarNovoBancoDeDados;

namespace TechPet.UseCase.UseCases.Empresas.IncluirEmpresa
{
    public class IncluirEmpresaUseCase : UseCaseCommand<IncluirEmpresaRequest, EmpresaResult?>, IIncluirEmpresaUseCase
    {
        private readonly IIncluirUsersCommand _incluirUsersCommand;
        private readonly ICriarNovoBancoDeDadosCommand _criarNovoBancoDeDadosCommand;
        private readonly IUnitOfWork _unitOfWork;

        public IncluirEmpresaUseCase(INotificacaoService notificacaoService, IMediator mediator, IUnitOfWork unitOfWork, ILogger<IncluirEmpresaUseCase> logger, IIncluirUsersCommand incluirUsersCommand, ICriarNovoBancoDeDadosCommand criarNovoBancoDeDadosCommand)
            : base(notificacaoService, mediator, unitOfWork, logger)
        {
            _incluirUsersCommand = incluirUsersCommand;
            _criarNovoBancoDeDadosCommand = criarNovoBancoDeDadosCommand;
            _unitOfWork = unitOfWork;
        }

        public async override Task<EmpresaResult?> ExecutarAsync(IncluirEmpresaRequest request)
        {
            try
            {
                var result = await AoExecutarAsync(request);

                if (_notificacaoService.ExisteNotificacao()) return default;

                return result;
            }
            catch (Exception ex)
            {
                _notificacaoService.AddNotificacaoErroInterno();
                _logger.LogError(ex, "Erro inesperado ao processar a requisição.");

                return default;
            }
        }

        protected async override Task<EmpresaResult?> AoExecutarAsync(IncluirEmpresaRequest request)
        {
            var novoBancoDeDados = request.Codigo;

            await IncluirUsuariosTechPet(request);
            if (_notificacaoService.ExisteNotificacao())
                return default;

            await _criarNovoBancoDeDadosCommand.ExecuteAsync(novoBancoDeDados);
            if (_notificacaoService.ExisteNotificacao())
            {
                await _incluirUsersCommand.UndoAsync();
                return default;
            }

            try
            {
                var commands = new List<object>();
                foreach (var userRequest in request.Usuarios)
                {
                    var registrarUsuarioCommand = new RegistrarUsuarioCommand(
                        userRequest.Nome,
                        userRequest.Email,
                        userRequest.Email,
                        userRequest.Senha);

                    commands.Add(registrarUsuarioCommand);
                }
                var tasks = commands.Select(command => _mediator.Send(command));

                var incluirEmpresaCommand = new IncluirEmpresaCommand(
                    request.Codigo,
                    request.Nome,
                    request.NomeFantasia,
                    request.Cnpj);

                var empresaResult = await _mediator.Send(incluirEmpresaCommand);

                await Task.WhenAll(tasks);
                await _unitOfWork.CommitAsync(novoBancoDeDados);

                if (_notificacaoService.ExisteNotificacao())
                {
                    await _incluirUsersCommand.UndoAsync();
                    await _criarNovoBancoDeDadosCommand.UndoAsync();
                    return default;
                }

                return empresaResult;
            }
            catch (Exception ex)
            {
                await _incluirUsersCommand.UndoAsync();
                await _criarNovoBancoDeDadosCommand.UndoAsync();
                _notificacaoService.AddNotificacaoErroInterno();
                _logger.LogError(ex, $"Erro inesperado ao tentar adicionar usuario e empresa no banco de dados do cliente {request.Codigo}.");
                return default;
            }
        }

        private Task IncluirUsuariosTechPet(IncluirEmpresaRequest request)
        {
            var incluirUsersCommandRequest = request.Usuarios.Select(usuarioRequest =>
            {
                var user = new User
                {
                    Nome = usuarioRequest.Nome,
                    UserName = usuarioRequest.Email,
                    Email = usuarioRequest.Email,
                    CodigoEmpresa = request.Codigo
                };
                return new IncluirUsersCommandRequest(user, usuarioRequest.Senha);
            });
            return _incluirUsersCommand.ExecuteAsync(incluirUsersCommandRequest);
        }

        //private async Task<IEnumerable<User>> IncluirUsuariosTechPet(IncluirEmpresaRequest request)
        //{
        //    var usersCriados = new List<User>();
        //    for (int userIndex = 0; userIndex < request.Usuarios.Count(); userIndex++)
        //    {
        //        var usuarioRequest = request.Usuarios.ElementAt(userIndex);
        //        var userIdentity = new User()
        //        {
        //            Email = usuarioRequest.Email,
        //            Nome = usuarioRequest.Nome,
        //            UserName = usuarioRequest.Email,
        //            CodigoEmpresa = request.Codigo
        //        };

        //        var result = await _identityService.CriarUsuarioAsync(userIdentity, usuarioRequest.Senha);

        //        if (!result.Sucesso)
        //        {
        //            _notificacaoService.AddNotificationsIdentity(result.Erros, userIdentity, _logger);
        //            RemoverUsuariosCriadosTechPet(usersCriados);
        //            break;
        //        }

        //        usersCriados.Add(userIdentity);
        //    }

        //    return usersCriados;
        //}

        //private async void RemoverUsuariosCriadosTechPet(IEnumerable<User> users)
        //{
        //    for (int userIndex = 0; userIndex < users.Count(); userIndex++)
        //    {
        //        var userIdentity = users.ElementAt(userIndex);

        //        var result = await _identityService.ExcluirUsuarioAsync(userIdentity);

        //        if (!result.Sucesso)
        //        {
        //            _notificacaoService.AddNotificationsIdentity(result.Erros, userIdentity, _logger);
        //        }
        //    }
        //}
    }
}
