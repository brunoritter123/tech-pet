using TechPet.Identity.DTOs;
using TechPet.Identity.Entities;

namespace TechPet.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<ResultadoIdentityDto> CriarUsuarioAsync(User user, string senha);
        Task<ResultadoIdentityDto<User>> BuscarPorUserNameAsync(string userName);
        Task<ResultadoIdentityDto<string>> GerarTokenConfirmacaoEmailAsync(User user);
        Task<ResultadoIdentityDto> ConfirmarEmailAsync(User user, string token);
        Task<ResultadoIdentityDto> ValidarSenhaAsync(User user, string senha);
        Task<string> GerarTokenParaResetDeSenhaAsync(User user);
        Task<ResultadoIdentityDto> ResetarSenhaAsync(User user, string token, string novaSenha);
        Task<ResultadoIdentityDto> ExcluirUsuarioAsync(User user);
    }
}
