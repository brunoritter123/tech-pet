using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.Domain.Abstractions.Notifications
{
    public class Notificacao
    {
        public string Mensagem { get; set; }
        public string DetalhamentoDaMensagem { get; set; }
        public NotificacaoTipo TipoDaNotificacao { get; set; }
        
        public Notificacao(string mensagem, string detalhamentoDaMensagem = "", NotificacaoTipo tipoDaNotificacao = NotificacaoTipo.Validacao)
        {
            if (string.IsNullOrEmpty(mensagem)) throw new ArgumentException("Argumento invalido", nameof(mensagem));

            Mensagem = mensagem;
            DetalhamentoDaMensagem = detalhamentoDaMensagem;
            TipoDaNotificacao = tipoDaNotificacao;
        }
    }
}
