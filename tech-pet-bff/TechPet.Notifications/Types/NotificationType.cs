using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.Notifications.Types
{
    public enum NotificationType
    {
        Validacao = StatusCodes.Status400BadRequest,
        SemAcesso = StatusCodes.Status403Forbidden,
        RecursoNaoEncontrado = StatusCodes.Status404NotFound,
        ErroInterno = StatusCodes.Status500InternalServerError
    }
}
