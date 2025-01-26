using Pressur.Domain.Abstractions.Entities;
using Pressur.Domain.Entities.Cadastros;

namespace Pressur.Domain.Entities.Vendas;

public class EntradaOrdemDeServico : Entity<long>
{
    public required Veiculo Veiculo { get; init; }
    public string KmAtual { get; set; } = "0";
    public string? DescricaoProblema { get; init; }
    public string? ObservacaoInterna { get; init; }
}