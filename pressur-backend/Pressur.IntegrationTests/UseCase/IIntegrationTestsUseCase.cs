using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressur.IntegrationTests.UseCase
{
    public interface IIntegrationTestsUseCase
    {
        Task ResetDataBaseAsync();
    }
}
