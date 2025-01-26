// using FluentValidation;
//
// namespace Pressur.Domain.Entities.Cadastros.Veiculos
// {
//     public class VeiculoValidador : AbstractValidator<Veiculo>
//     {
//         public VeiculoValidador()
//         {
//             RuleFor(x => x.Placa)
//                 .NotEmpty()
//                 .Matches(@"^[A-Z]{3}-\d[A-Z]\d{2}$|^[A-Z]{3}-\d{4}$");
//             
//             RuleFor(x => x.Ano)
//                 .Matches(@"^\d{4}$")
//                 .When(x => string.IsNullOrWhiteSpace(x.Ano));
//         }
//     }
// }
