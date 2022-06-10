using FluentValidation.Results;

namespace TechPet.Domain.Abstractions.Notifications
{
    public class NotificacaoService : INotificacaoService
    {
        private List<Notificacao> _notificacoes = new List<Notificacao>();
        private NotificacaoTipo? _tipoNotificacao = default;

        public void AddNotificacao(string mensagem, string detalhesDaMensagem = "", NotificacaoTipo tipo = NotificacaoTipo.Validacao)
        {
            _notificacoes.Add(new Notificacao(mensagem, detalhesDaMensagem, tipo));
            SetTipoErro(tipo);
        }

        private void SetTipoErro(NotificacaoTipo novoTipo)
        {
            if (!_tipoNotificacao.HasValue)
            {
                _tipoNotificacao = novoTipo;
                return;
            }
            _tipoNotificacao = novoTipo > _tipoNotificacao ? novoTipo : _tipoNotificacao;
        }

        public bool ExisteNotificacao()
            => _notificacoes.ElementAtOrDefault(0) != null;

        public IEnumerable<Notificacao> GetNotificacoes()
            => _notificacoes;

        public NotificacaoTipo? GetTipoNotificacao()
            => _tipoNotificacao;

        public void AddNotificacaoErroInterno()
        {
            _notificacoes.Add(new Notificacao(
                "Erro internado da aplicação",
                "Entre em contato com o administrador do sistema para obter suporte.",
                NotificacaoTipo.ErroInterno));
            SetTipoErro(NotificacaoTipo.ErroInterno);
        }

        public void AddNotificacao(string mensagem, string detalhesDaMensagem, IEnumerable<ValidationFailure> erros, NotificacaoTipo tipo = NotificacaoTipo.Validacao)
        {
            var notificacoes = erros.Select(erro => new Notificacao(
                $"Campo '{erro.PropertyName}' inválido.",
                erro.ErrorMessage,
                tipo));

            _notificacoes.AddRange(notificacoes);
            _notificacoes.Add(new Notificacao(mensagem, detalhesDaMensagem, tipo));
            SetTipoErro(tipo);
        }
    }
}
