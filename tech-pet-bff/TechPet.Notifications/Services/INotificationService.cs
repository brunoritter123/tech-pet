using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Notifications.Types;

namespace TechPet.Notifications.Services
{
    public interface INotificationService
    {
        bool ExisteNotificacao();
        void AddErro(string mensagem, NotificationType tipo = NotificationType.Validacao);
        void AddErro(string propriedade, string mensagem, NotificationType tipo = NotificationType.Validacao);
    }
}
