using Pressur.Domain.Abstractions.FluentResults;

namespace Pressur.Application.Abstractions
{
    public interface ICommandHandler<in TRequest, TResult>
    {
        Task<Result<TResult>> ExecutarAsync(TRequest request, CancellationToken cancellationToken);
    }

    public interface ICommandHandler<TResult>
    {
        Task<Result<TResult>> ExecutarAsync(CancellationToken cancellationToken);
    }
}
