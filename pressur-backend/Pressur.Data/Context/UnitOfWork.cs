using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressur.Data.Abstractions;

namespace Pressur.Data.Context
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly PressurContext _dbContext;
        public UnitOfWork(PressurContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CommitAsync() => _dbContext.SaveChangesAsync();
    }
}
