using Microsoft.AspNetCore.Identity;
using Pressur.Domain.Abstractions.FluentResults;
using Pressur.Identity.Entities;
using Pressur.Identity.Interfaces;

namespace Pressur.Identity.Services

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

        public async Task<Result<User>> BuscarPorUserNameAsync(string userName)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                    throw new Exception($"Usuário '{userName}' não encontrado");

                return new Result<User>(user);
            }
            catch (Exception ex)
            {
                var erro = new AppErro("BuscarPorUserName", ex.Message);
                return new Result<User>(erro);
            }

        }

        public async Task<Result> ConfirmarEmailAsync(User user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return new Result();

            var erros = result.Errors
                .Select(erro => new AppErro(erro.Code, erro.Description))
                .ToList();
            return new Result(erros);
        }

        public async Task<Result> CriarUsuarioAsync(User user, string senha)
        {
            if (string.IsNullOrWhiteSpace(user.CodigoEmpresa))
            {
                return new Result(new AppErro("EntityInvalid", "Código da empresa é obrigatório."));
            }

            var result = await _userManager.CreateAsync(user, senha);
            if (result.Succeeded)
                return new Result();

            var erros = result.Errors
                .Select(erro => new AppErro(erro.Code, erro.Description))
                .ToList();
            return new Result(erros);
        }

        public async Task<Result> ExcluirUsuarioAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return new Result();

            var erros = new List<AppErro>();
            foreach (var erro in result.Errors)
            {
                erros.Add(new AppErro(erro.Code, erro.Description));
            }
            return new Result(erros);
        }

        public async Task<Result<string>> GerarTokenConfirmacaoEmailAsync(User user)
        {
            try
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return new Result<string>(token);

            }
            catch (Exception ex)
            {
                var erro = new AppErro("GerarTokenConfirmacaoEmailAsync", ex.Message);
                return new Result<string>(erro);
            }
        }

        public Task<string> GerarTokenParaResetDeSenhaAsync(User user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<Result> ResetarSenhaAsync(User user, string token, string novaSenha)
        {
            var result = await _userManager.ResetPasswordAsync(user, token, novaSenha);

            if (result.Succeeded)
                return new Result();

            var erros = result.Errors
                .Select(erro => new AppErro(erro.Code, erro.Description))
                .ToList();
            return new Result(erros);
        }

        public async Task<Result> ValidarSenhaAsync(User user, string senha)
        {
            // await _userManager.AddPasswordAsync(user, "teste");
            var result = await _singInManager.CheckPasswordSignInAsync(user, senha, false);
            return result.Succeeded 
                ? new Result() 
                : new Result(new AppErro("", "Usuário ou senha estão incorretos."));
        }
    }
}
