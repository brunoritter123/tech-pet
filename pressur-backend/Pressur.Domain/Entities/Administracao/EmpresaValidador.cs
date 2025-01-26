// using FluentValidation;
// using Pressur.Domain.Entities.Administracao;
// using Pressur.Domain.ValueObjects.CnpjObject;
//
// namespace Pressur.Domain.Entities.Empresas
// {
//     public class EmpresaValidador : AbstractValidator<Empresa>
//     {
//         public EmpresaValidador()
//         {
//             RuleFor(x => x.CodigoEmpresa)
//                 .NotEmpty()
//                 .MaximumLength(Empresa.TamanhoMaximoCodigo)
//                 .Matches("[a-zA-Z0-9]+")
//                 .WithMessage("Código só pode conter letras e números");
//
//             RuleFor(x => x.NomeFantasia)
//                 .NotEmpty()
//                 .MaximumLength(Empresa.TamanhoMaximoNomeFantasia);
//
//             RuleFor(x => x.Nome)
//                 .NotEmpty()
//                 .MaximumLength(Empresa.TamanhoMaximoNome);
//
//             RuleFor(x => x.Cnpj)
//                 .NotNull()
//                 .SetValidator(new CnpjValidador());
//         }
//     }
// }
