using FluentValidation.Results;
using Newtonsoft.Json;

namespace TechPet.API.Results
{
    public class ResultDefault
    {
        [JsonProperty("sucesso")]
        public bool Sucesso { get; private set; }

        [JsonProperty("erros")]
        public IEnumerable<ResultErro> Erros { get; set; } = new List<ResultErro>();

        public ResultDefault(string erro)
        {
            Sucesso = false;
            Erros = new List<ResultErro>()
            {
                new ResultErro(erro)
            };
        }

        public ResultDefault()
            => Sucesso=true;

        public ResultDefault(IEnumerable<ValidationFailure> validacoes)
        {
            Sucesso = false;
            Erros = validacoes.Select(x => new ResultErro(x.ErrorMessage, x.PropertyName)).ToList();
        }
    }
    public class ResultDefault<TData> : ResultDefault
    {
        [JsonProperty("dados")]
        public TData? Dados { get; set; }

        public ResultDefault(TData? dados)
            => Dados = dados;
    }
}
