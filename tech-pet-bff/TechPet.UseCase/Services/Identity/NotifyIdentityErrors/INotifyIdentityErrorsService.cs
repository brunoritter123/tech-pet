using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Identity.DTOs;

namespace TechPet.UseCase.Services.Identity.NotifyIdentityErrors
{
    public interface INotifyIdentityErrorsService
    {
        void AddNotifications(IEnumerable<ErroIdentityDto> erros);
    }
}
