using FluentValidation.Results;

namespace TechPet.Domain.Abstractions.Notifications
{
    public class NotificacaoService : INotificacaoService
    {
        private List<ValidationFailure> _erros = new List<ValidationFailure>();
        private NotificacaoTipo? _tipoErro = default;

        public void AddErro(string mensagem, NotificacaoTipo tipo = NotificacaoTipo.Validacao)
        {
            _erros.Add(new ValidationFailure(default, mensagem));
            SetTipoErro(tipo);
        }

        public void AddErro(string mensagem, string propriedade, NotificacaoTipo tipo = NotificacaoTipo.Validacao)
        {
            _erros.Add(new ValidationFailure(propriedade, mensagem));
            SetTipoErro(tipo);
        }

        private void SetTipoErro(NotificacaoTipo novoTipo)
        {
            if (!_tipoErro.HasValue)
            {
                _tipoErro = novoTipo;
                return;
            }
            _tipoErro = novoTipo > _tipoErro ? novoTipo : _tipoErro;
        }

        public bool ExisteNotificacao()
            => _erros.ElementAtOrDefault(0) != null;

        public IEnumerable<ValidationFailure> GetErros()
            => _erros;

        public NotificacaoTipo? GetTipoErro()
            => _tipoErro;

        public void AddErro(Exception ex)
        {
            _erros.Add(new ValidationFailure(default, ex.Message));
            SetTipoErro(NotificacaoTipo.ErroInterno);
        }

        public void AddErro(IEnumerable<ValidationFailure> erros, NotificacaoTipo tipo = NotificacaoTipo.Validacao)
        {
            _erros.AddRange(erros);
            SetTipoErro(tipo);
        }
    }
}
