using TechPet.Domain.Entities.Empresas.Commands.IncluirEmpresa;
using TechPet.Domain.Entities.Empresas.Results;
using TechPet.Domain.ValueObjects.CnpjObject;

namespace TechPet.Domain.Entities.Empresas.Mappers
{
    public static class EmpresaMapper
    {
        public static Empresa ToEmpresa(this IncluirEmpresaCommand command)
            => new Empresa(command.Codigo, command.Nome, command.NomeFantasia, command.Cnpj);

        public static EmpresaResult ToEmpresaResult(this Empresa empresa)
            => new EmpresaResult(empresa.Nome, empresa.NomeFantasia, empresa.Cnpj.Valor);
    }
}
