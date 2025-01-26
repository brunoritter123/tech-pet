namespace Pressur.Domain.Abstractions.FluentResults;

public record class AppErro(
    string CodigoErro,
    string MensagemErro,
    ErroTipo ErroTipo = ErroTipo.Validacao,
    string DetalhesErro = "");

public enum ErroTipo
{
    Error,
    Validacao,
    Autenticacao
}
