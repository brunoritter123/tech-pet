namespace TechPet.Domain.Entities.Usuarios
{
    public class UsuarioResult
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public UsuarioResult(string login, string nome, string email)
        {
            Login = login;
            Nome = nome;
            Email = email;
        }
    }
}
