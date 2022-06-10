using TechPet.Domain.Entities.Usuarios;

namespace TechPet.UseCase.UseCases.Usuarios.Logar
{
    public class LogarUsuarioResponse
    {
        public string Token { get; set; }
        public UsuarioResult User { get; set; }

        public LogarUsuarioResponse(string token, UsuarioResult user)
        {
            Token = token;
            User = user;
        }
    }
}
