namespace TechPet.Domain.Abstractions.FluentResults;

public class Result<TSucesso>
{
    private readonly TSucesso? _objSucesso;
    private readonly IList<AppErro> _appErros = [];

    public TSucesso GetResultSucesso() => _objSucesso ?? throw new NullReferenceException();
    public bool Sucesso => _appErros.Any();
    public Result(TSucesso objSucesso) => _objSucesso = objSucesso;

    public Result(AppErro appErro) => _appErros.Add(appErro);
    
    public Result<TSucesso> WithErro(AppErro appErro)
    {
        _appErros.Add(appErro);
        return this;
    }
    
    public void If(
        Action<TSucesso> seSucesso, 
        Action<IEnumerable<AppErro>> seErro)
    {
        
        if (Sucesso) seSucesso(GetResultSucesso());
        else seErro(_appErros);
    }
    
    public static void Try<TSucessoTry>(
        Func<Result<TSucessoTry>> funcaoExecucao,
        Action<TSucessoTry> seSucesso, 
        Action<IEnumerable<AppErro>> seErro,
        Action<Exception> seException)
    {
        try
        {
            var result = funcaoExecucao();
            result.If(seSucesso, seErro);
        }
        catch (Exception e)
        {
            seException(e);
        }
    }

    public static implicit operator Result<TSucesso>(TSucesso objSucesso)
    {
        return new Result<TSucesso>(objSucesso);
    }
    
    public static implicit operator Result<TSucesso>(AppErro appErro)
    {
        return new Result<TSucesso>(appErro);
    }
}