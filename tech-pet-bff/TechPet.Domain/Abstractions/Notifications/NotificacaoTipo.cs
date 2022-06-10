namespace TechPet.Domain.Abstractions.Notifications
{
    public enum NotificacaoTipo : ushort
    {
        Validacao = 400,
        ErroNasCredenciais = 401,
        SemAcesso = 403,
        RecursoNaoEncontrado = 404,
        ErroInterno = 500
    }
}
