using Newtonsoft.Json;

namespace TechPet.API.Results
{
    public class ResultErro
    {
        [JsonProperty("menssagem")]
        public string Menssagem { get; set; } = string.Empty;
        [JsonProperty("campo")]
        public string? Campo { get; set; }

        public ResultErro(string menssagem, string? campo = null)
        {
            Menssagem = menssagem;
            Campo = campo;
        }
    }
}
