using FluentValidation.Results;

namespace TechPet.Domain.Abstractions.Notifications
{
    public interface INotificacaoService
    {
        bool ExisteNotificacao();
        void AddNotificacao(string mensagem, string detalhesDaMensagem = "", NotificacaoTipo tipo = NotificacaoTipo.Validacao);
        IEnumerable<Notificacao> GetNotificacoes();
        NotificacaoTipo? GetTipoNotificacao();
        void AddNotificacaoErroInterno();
        void AddNotificacao(string mensagem, string detalhesDaMensagem, IEnumerable<ValidationFailure> errors, NotificacaoTipo tipo = NotificacaoTipo.Validacao);
    }
}
