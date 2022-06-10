using MediatR;
using TechPet.Domain.Entities.Empresas.Results;

namespace TechPet.Domain.Entities.Empresas.Commands.IncluirEmpresa
{
    public class IncluirEmpresaCommand : IRequest<EmpresaResult?>
    {
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        public IncluirEmpresaCommand(string nome, string nomeFantasia, string cnpj)
        {
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
        }
    }
}
