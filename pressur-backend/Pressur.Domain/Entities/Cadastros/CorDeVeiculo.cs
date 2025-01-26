using Pressur.Domain.Abstractions.Entities;

namespace Pressur.Domain.Entities.Cadastros;

public class CorDeVeiculo : Entity<short>
{
    public const int TamanhoMaximoNome = 10;
    public string Nome { get; private set; }

    public CorDeVeiculo(string nome)
    {
        Nome = nome;
    }

    public static CorDeVeiculo Create(string codigoEmpresa, short id, string nome)
    {
        var cor = new CorDeVeiculo(nome);
        cor.CodigoEmpresa = codigoEmpresa;
        cor.Id = id;
        return cor;
    }
}