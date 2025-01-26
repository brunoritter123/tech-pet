using Pressur.Domain.Entities.Administracao;

namespace Pressur.Application.Features.Empresas.IncluirEmpresa;

public record IncluirEmpresaCommand(
    string Codigo,
    string Nome,
    string NomeFantasia,
    string Cnpj,
    IEnumerable<IncluirEmpresaCommand.UsuarioDto> Usuarios)
{

    public record UsuarioDto(
        string Nome,
        string Email,
        string Senha)
    {
        public static implicit operator Usuario(UsuarioDto dto)
        {
            return new Usuario(
                login: dto.Email,
                nome: dto.Nome,
                email: dto.Email
            );
        }
    }
}
