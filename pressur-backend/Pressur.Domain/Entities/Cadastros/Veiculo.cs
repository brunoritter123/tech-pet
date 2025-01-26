using Pressur.Domain.Abstractions.Entities;

namespace Pressur.Domain.Entities.Cadastros;

public class Veiculo : Entity<long>
{
    public const int TamanhoMaximoNome = 10;

    public required string Placa { get; set; }
    public ModeloDeVeiculo? Modelo { get; set; }
    public CorDeVeiculo? Cor { get; set; }
    public string? Ano { get; set; }
    public Contato? Contato { get; set; }
}