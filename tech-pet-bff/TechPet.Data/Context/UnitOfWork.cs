using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Data.Abstractions;

namespace TechPet.Data.Context
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly TechPetContext _dbContext;
        public UnitOfWork(TechPetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CommitAsync() => _dbContext.SaveChangesAsync();

        public Task CommitAsync(string nomeBancoDeDados)
        {
            _dbContext.UseDataBase(nomeBancoDeDados);
            return _dbContext.SaveChangesAsync();
        }
    }
}
