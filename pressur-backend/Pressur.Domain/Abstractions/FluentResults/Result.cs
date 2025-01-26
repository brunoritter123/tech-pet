namespace Pressur.Domain.Abstractions.FluentResults;

public class Result
{
    protected readonly List<AppErro> AppErros = [];
    public bool Sucesso => !AppErros.Any();
    

    public Result(){}
    public Result(AppErro appErro) => AppErros.Add(appErro);
    
    public Result(IEnumerable<AppErro> appErros) => AppErros.AddRange(appErros);
    
    public Result WithErro(AppErro appErro)
    {
        AppErros.Add(appErro);
        return this;
    }
    
    public IReadOnlyList<AppErro> GetErros() => AppErros.AsReadOnly();
    
    public void If(
        Action seSucesso, 
        Action<IEnumerable<AppErro>> seErro)
    {
        
        if (Sucesso) seSucesso();
        else seErro(AppErros);
    }
    
    public static Result Fail(
        string codigoErro,
        string menssagemErro,
        ErroTipo erroTipo = ErroTipo.Validacao) => new (new AppErro(codigoErro, menssagemErro, erroTipo));
    
    public static void Try(
        Func<Result> funcaoExecucao,
        Action seSucesso, 
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
    
    public static implicit operator Result(AppErro appErro)
    {
        return new Result(appErro);
    }
}

public class Result<TSucesso> : Result
{
    
    private readonly TSucesso? _objSucesso;
    
    public TSucesso GetResultSucesso() => _objSucesso ?? throw new NullReferenceException();
    public TSucesso? GetOpcionalResultSucesso() => _objSucesso;
    
    public Result(TSucesso objSucesso) => _objSucesso = objSucesso;

    public Result(AppErro appErro) : base(appErro) { }
    public Result(IEnumerable<AppErro> appErros) : base(appErros) { }

    public void If(
        Action<TSucesso> seSucesso, 
        Action<IEnumerable<AppErro>> seErro)
    {
        
        if (Sucesso) seSucesso(GetResultSucesso());
        else seErro(AppErros);
    }
    
    public Result<TSucessoDestino> ConvertResult<TSucessoDestino>(Func<TSucesso, TSucessoDestino> seSucesso)
    {
        if (!Sucesso) 
            return new Result<TSucessoDestino>(GetErros());
        
        var resultDestino = seSucesso(GetResultSucesso());
        return new Result<TSucessoDestino>(resultDestino);
    }
    
    public new static Result<TSucesso> Fail(
        string codigoErro,
        string menssagemErro,
        ErroTipo erroTipo = ErroTipo.Validacao,
        string detalhesErro = "")
        => new (new AppErro(codigoErro, menssagemErro, erroTipo, detalhesErro));
    
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

    public static Result<TSucesso> FromResultFail(Result result)
    {
        if (result.Sucesso) throw new Exception("'Result' precisa conter erros para a conversão");
        return new Result<TSucesso>(result.GetErros());
    }
}