using Pressur.Domain.Entities.Administracao;

namespace Pressur.Application.Features.Empresas.IncluirEmpresa;

public class IncluirEmpresaResponse
{
    public required string Nome { get; init; }
    public required string NomeFantasia { get; init; }
    public required string Cnpj { get; init; }

    public static implicit operator IncluirEmpresaResponse(Empresa entity)
    {
        return new IncluirEmpresaResponse()
        {
            Nome = entity.Nome,
            NomeFantasia = entity.NomeFantasia,
            Cnpj = entity.Cnpj.ToString()
        };
    }
}

