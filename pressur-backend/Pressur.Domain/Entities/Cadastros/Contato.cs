using Pressur.Domain.Abstractions.Entities;

namespace Pressur.Domain.Entities.Cadastros;
public class Contato : Entity<int>
{
    public string? Nome { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? ObservacaoDoCliente { get; set; }
}
