using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.Application.Abstractions
{
    public interface ICommand
    {
        public Task UndoAsync();
    }
    public interface ICommand<TResult> : ICommand
    {
        public Task<TResult> ExecuteAsync();
    }

    public interface ICommand<TResult, TRequest> : ICommand
    {
        public Task<TResult> ExecuteAsync(TRequest request);
    }

    public interface ICommand<TResult, TRequest, TRequest2> : ICommand
    {
        public Task<TResult> ExecuteAsync(TRequest request, TRequest2 request2);
    }
}
