using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.IntegrationTests.UseCase
{
    public interface IIntegrationTestsUseCase
    {
        Task ResetDataBaseAsync();
    }
}
