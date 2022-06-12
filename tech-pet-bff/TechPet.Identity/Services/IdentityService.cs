using Microsoft.AspNetCore.Identity;
using TechPet.Identity.DTOs;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;

namespace TechPet.Identity.Services

{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;

        public IdentityService(UserManager<User> userManager, SignInManager<User> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        public async Task<ResultadoIdentityDto<User>> BuscarPorUserNameAsync(string userName)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                    throw new Exception($"Usuário '{userName}' não encontrado");

                return new ResultadoIdentityDto<User>(user);
            }
            catch (Exception ex)
            {
                var erro = new ErroIdentityDto("BuscarPorUserName", ex.Message);
                return new ResultadoIdentityDto<User>(erro);
            }

        }

        public async Task<ResultadoIdentityDto> ConfirmarEmailAsync(User user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return new ResultadoIdentityDto();

            var erros = new List<ErroIdentityDto>();
            foreach (var erro in result.Errors)
            {
                erros.Add(new ErroIdentityDto(erro.Code, erro.Description));
            }
            return new ResultadoIdentityDto(erros);
        }

        public async Task<ResultadoIdentityDto> CriarUsuarioAsync(User user, string senha)
        {
            if (string.IsNullOrWhiteSpace(user.CodigoEmpresa))
            {
                return new ResultadoIdentityDto(new ErroIdentityDto("EntityInvalid", "Código da empresa é obrigatório."));
            }

            var result = await _userManager.CreateAsync(user, senha);
            if (result.Succeeded)
                return new ResultadoIdentityDto();

            var erros = new List<ErroIdentityDto>();
            foreach (var erro in result.Errors)
            {
                erros.Add(new ErroIdentityDto(erro.Code, erro.Description));
            }
            return new ResultadoIdentityDto(erros);
        }

        public async Task<ResultadoIdentityDto> ExcluirUsuarioAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return new ResultadoIdentityDto();

            var erros = new List<ErroIdentityDto>();
            foreach (var erro in result.Errors)
            {
                erros.Add(new ErroIdentityDto(erro.Code, erro.Description));
            }
            return new ResultadoIdentityDto(erros);
        }

        public async Task<ResultadoIdentityDto<string>> GerarTokenConfirmacaoEmailAsync(User user)
        {
            try
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return new ResultadoIdentityDto<string>(token);

            }
            catch (Exception ex)
            {
                var erro = new ErroIdentityDto("GerarTokenConfirmacaoEmailAsync", ex.Message);
                return new ResultadoIdentityDto<string>(erro);
            }
        }

        public Task<string> GerarTokenParaResetDeSenhaAsync(User user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<ResultadoIdentityDto> ResetarSenhaAsync(User user, string token, string novaSenha)
        {
            var result = await _userManager.ResetPasswordAsync(user, token, novaSenha);

            if (result.Succeeded)
                return new ResultadoIdentityDto();

            var erros = new List<ErroIdentityDto>();
            foreach (var erro in result.Errors)
            {
                erros.Add(new ErroIdentityDto(erro.Code, erro.Description));
            }
            return new ResultadoIdentityDto(erros);
        }

        public async Task<ResultadoIdentityDto> ValidarSenhaAsync(User user, string senha)
        {
            var result = await _singInManager.CheckPasswordSignInAsync(user, senha, false);
            if (result.Succeeded)
                return new ResultadoIdentityDto();

            return new ResultadoIdentityDto(new ErroIdentityDto("", "Usuário ou senha estão incorretos."));

        }
    }
}
