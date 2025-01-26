using Pressur.Data.Context;
using Pressur.Domain.Entities.Cadastros;

namespace Pressur.Data.Seeds
{
    public static class CorDeVeiculoSeed
    {
        public static IEnumerable<CorDeVeiculo> Gerar()
        {
            return new List<CorDeVeiculo>()
            {
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,1, "Prata"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,2, "Preto"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,3, "Vermelho"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,4, "Verde"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,5, "Laranja"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,6, "Azul"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,7, "Branco"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,8, "Cinza"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,9, "Marrom"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,10, "Bege"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,11, "Dourado"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,12, "Rosa"),
                CorDeVeiculo.Create(PressurContext.NomePadraoCodigoEmpresa,13, "Roxo"),
            };
        }
    }
}