using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPet.Domain.Abstractions.Entities;

namespace TechPet.Domain.Entities.Cadastros.ModelosDeVeiculo
{
    public class ModeloDeVeiculo : Entity<int>
    {
        public string Nome { get; private set; }

        public ModeloDeVeiculo(string nome)
        {
            Nome = nome;
        }
        public static ModeloDeVeiculo Create(int id, string nome)
        {
            var modelo = new ModeloDeVeiculo(nome);
            modelo.Id = id;
            return modelo;
        }

        public override NomeAmigavelDaEntitidade GetNomeDaEntitidadeAmigavel()
            => new NomeAmigavelDaEntitidade("do", "dos", "modelo de veiculo", "modelos de veiculos");

        public override bool Validar()
            => OnValidate(this, new ModeloDeVeiculoValidador());
    }
}
