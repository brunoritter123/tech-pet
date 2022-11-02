using Newtonsoft.Json;
using System.Linq;
using TechPet.Domain.Abstractions.Notifications;

namespace TechPet.API.Responses
{
    public class ErrorResponse
    {

        [JsonProperty("code")]
        public short Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("detailedMessage")]
        public string? DetailedMessage { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("details")]
        public IEnumerable<ErrorResponse>? Details { get; set; }

        public ErrorResponse(string message, NotificacaoTipo tipo, string? detailedMessage)
        {
            Code = (short)tipo;
            Message = message;
            DetailedMessage = detailedMessage;
            Type = "error";
        }

        public ErrorResponse(Exception exception)
        {
            Code = (short)NotificacaoTipo.ErroInterno;
            Message = "Erro internado da aplicação";
            DetailedMessage = $"Entre em contato com o administrador do sistema para obter suporte.";
            Type = "error";
        }

        public ErrorResponse(INotificacaoService notificacao)
        {
            var tipoDeErro = notificacao.GetTipoNotificacao();
            if (!notificacao.ExisteNotificacao() || tipoDeErro is null)
            {
                throw new ArgumentException("Notificação invalida para gerar ErrorResponse", nameof(notificacao));
            }

            var notificacoes = notificacao.GetNotificacoes().ToList();

            Code = (short)tipoDeErro;
            Message = notificacoes.Last().Mensagem;
            DetailedMessage = notificacoes.Last().DetalhamentoDaMensagem;
            Type = "error";

            if (notificacoes.Count > 1)
            {
                notificacoes.RemoveAt(notificacoes.Count() - 1);
                Details = notificacoes.Select(notificacao =>
                {
                    return new ErrorResponse(
                        notificacao.Mensagem,
                        notificacao.TipoDaNotificacao,
                        notificacao.DetalhamentoDaMensagem);
                });
            }
        }

        public ErrorResponse(List<Notificacao> notificacoes, NotificacaoTipo notificacaoTipo = NotificacaoTipo.Validacao, string tipo = "error")
        {
            Code = (short)notificacaoTipo;
            Message = notificacoes.Last().Mensagem;
            DetailedMessage = notificacoes.Last().DetalhamentoDaMensagem;
            Type = tipo;

            if (notificacoes.Count > 1)
            {
                notificacoes.RemoveAt(notificacoes.Count() - 1);
                Details = notificacoes.Select(notificacao =>
                {
                    return new ErrorResponse(
                        notificacao.Mensagem,
                        notificacao.TipoDaNotificacao,
                        notificacao.DetalhamentoDaMensagem);
                });
            }
        }
    }
}
