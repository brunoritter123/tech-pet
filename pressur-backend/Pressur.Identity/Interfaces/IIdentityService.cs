using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Identity.DTOs;
using Pressur.Identity.Entities;

namespace Pressur.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<Result> CriarUsuarioAsync(User user, string senha);
        Task<Result<User>> BuscarPorUserNameAsync(string userName);
        Task<Result<string>> GerarTokenConfirmacaoEmailAsync(User user);
        Task<Result> ConfirmarEmailAsync(User user, string token);
        Task<Result> ValidarSenhaAsync(User user, string senha);
        Task<string> GerarTokenParaResetDeSenhaAsync(User user);
        Task<Result> ResetarSenhaAsync(User user, string token, string novaSenha);
        Task<Result> ExcluirUsuarioAsync(User user);
    }
}
