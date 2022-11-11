using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPet.UseCase.UseCases.Empresas.IncluirEmpresa
{
    public class IncluirEmpresaRequest
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }

        public class Usuario
        {
            public string Nome { get; set; }

            public string Email { get; set; }

            public string Senha { get; set; }
        }
    }
}
