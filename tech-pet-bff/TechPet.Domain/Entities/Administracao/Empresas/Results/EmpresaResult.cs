using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.ValueObjects.CnpjObject;

namespace TechPet.Domain.Entities.Empresas.Results
{
    public class EmpresaResult
    {
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        public EmpresaResult(string nome, string nomeFantasia, string cnpj)
        {
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
        }
    }
}
