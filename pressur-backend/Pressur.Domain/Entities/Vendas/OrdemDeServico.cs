using Pressur.Domain.Abstractions.Entities;
using Pressur.Domain.Entities.Cadastros;

namespace Pressur.Domain.Entities.Vendas;

public class OrdemDeServico : Entity<long>
{
    public required Veiculo Veiculo { get; set; }
    // public TYPE Type { get; set; }
}
