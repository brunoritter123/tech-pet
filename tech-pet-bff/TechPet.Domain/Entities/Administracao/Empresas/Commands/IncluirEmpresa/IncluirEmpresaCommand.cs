using MediatR;
using TechPet.Domain.Entities.Empresas.Results;

namespace TechPet.Domain.Entities.Empresas.Commands.IncluirEmpresa
{
    public class IncluirEmpresaCommand : IRequest<EmpresaResult?>
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        public IncluirEmpresaCommand(string codigo, string nome, string nomeFantasia, string cnpj)
        {
            Codigo = codigo;
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
        }
    }
}
