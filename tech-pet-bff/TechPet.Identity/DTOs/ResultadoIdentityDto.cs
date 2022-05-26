namespace TechPet.Identity.DTOs
{
    public class ResultadoIdentityDto
    {
        public ResultadoIdentityDto()
        {
            Sucesso = true;
        }

        public ResultadoIdentityDto(ErroIdentityDto erro)
        {
            Sucesso = false;
            Erros = new List<ErroIdentityDto>()
            {
                erro
            };
        }

        public ResultadoIdentityDto(IEnumerable<ErroIdentityDto> erros)
        {
            Sucesso = false;
            Erros = erros;
        }

        public bool Sucesso { get; private set; }
        public IEnumerable<ErroIdentityDto> Erros { get; private set; } = new List<ErroIdentityDto>();
    }

    public class ResultadoIdentityDto<T> : ResultadoIdentityDto
    {
        public ResultadoIdentityDto(T resultado) : base()
        {
            Resultado = resultado;
        }

        public ResultadoIdentityDto(IEnumerable<ErroIdentityDto> erros) : base(erros) { }
        public ResultadoIdentityDto(ErroIdentityDto erro) : base(erro) { }

        public T? Resultado { get; private set; }
    }

    public class ErroIdentityDto
    {
        public ErroIdentityDto(string codigo, string menssagem)
        {
            Codigo = codigo;
            Menssagem = menssagem;
        }
        public string Codigo { get; set; }
        public string Menssagem { get; set; }
    }
}
