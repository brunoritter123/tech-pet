namespace TechPet.UseCase.Abstractions
{
    public interface IUseCase<TRequest, TResult>
    {
        Task<TResult?> ExecutarAsync(TRequest request);
    }

    public interface IUseCase<TResult>
    {
        Task<TResult?> ExecutarAsync();
    }
}
