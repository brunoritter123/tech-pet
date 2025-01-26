using Newtonsoft.Json;
using Pressur.Domain.Abstractions.FluentResults;

namespace Pressur.API.Responses;

public class ErrorResponse
{

    [JsonProperty("code")]
    public short Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("detailedMessage")]
    public string? DetailedMessage { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("details")]
    public IEnumerable<ErrorResponse>? Details { get; set; }

    public ErrorResponse (AppErro appErro)
    {
        Code = (short)appErro.ErroTipo;
        DetailedMessage = appErro.DetalhesErro;
        Message = appErro.MensagemErro;
        Type = appErro.ErroTipo.ToString();
    }

    public static ErrorResponse FromAppErros(IEnumerable<AppErro> appErros)
    {
        var listAppErros = appErros.ToList();
        var appErroFirst = listAppErros.FirstOrDefault() ?? throw new ArgumentException("Erro na conversão de erros", nameof(appErros));

        return new ErrorResponse(appErroFirst)
        {
            Details = listAppErros
                .Skip(1)
                .Select(x => new ErrorResponse(x)).ToArray()
        };
    }

    public ErrorResponse(Exception exception)
    {
        Code = (short)ErroTipo.Error;
        Message = "Erro internado da aplicação";
        DetailedMessage = $"Entre em contato com o administrador do sistema para obter suporte.";
        Type = "error";
    }
}

