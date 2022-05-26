using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.Data.Abstractions
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
