using FluentValidation.Results;
using TechPet.Notifications.Types;

namespace TechPet.Notifications.Services
{
    public class NotificationService : INotificationService
    {
        private List<ValidationFailure> _erros = new List<ValidationFailure>();
        private NotificationType? _tipoErro = default;

        public void AddErro(string mensagem, NotificationType tipo = NotificationType.Validacao)
        {
            _erros.Add(new ValidationFailure(default, mensagem));
            SetTipoErro(tipo);
        }

        public void AddErro(string propriedade, string mensagem, NotificationType tipo = NotificationType.Validacao)
        {
            _erros.Add(new ValidationFailure(propriedade, mensagem));
            SetTipoErro(tipo);
        }

        private void SetTipoErro(NotificationType novoTipo)
            => _tipoErro = novoTipo > _tipoErro ? novoTipo : _tipoErro;

        public bool ExisteNotificacao()
            => _erros.ElementAtOrDefault(0) != null;
    }
}
