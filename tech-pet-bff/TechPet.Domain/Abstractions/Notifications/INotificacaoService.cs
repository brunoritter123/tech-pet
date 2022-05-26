using FluentValidation.Results;

namespace TechPet.Domain.Abstractions.Notifications
{
    public interface INotificacaoService
    {
        bool ExisteNotificacao();
        void AddErro(string mensagem, NotificacaoTipo tipo = NotificacaoTipo.Validacao);
        void AddErro(string mensagem, string propriedade, NotificacaoTipo tipo = NotificacaoTipo.Validacao);
        IEnumerable<ValidationFailure> GetErros();
        NotificacaoTipo? GetTipoErro();
        void AddErro(Exception ex);
        void AddErro(IEnumerable<ValidationFailure> errors, NotificacaoTipo tipo = NotificacaoTipo.Validacao);
    }
}
