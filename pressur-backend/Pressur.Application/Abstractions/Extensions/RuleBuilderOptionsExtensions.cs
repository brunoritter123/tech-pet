using FluentValidation;

namespace Pressur.Application.Abstractions.Extensions;

public static class RuleBuilderOptionsExtensions
{
    public static IRuleBuilderOptions<T, string> TamanhoExato<T>(this IRuleBuilder<T, string> ruleBuilder, int exactLength)
        => ruleBuilder
            .Length(exactLength)
            .WithMessage($"{{PropertyName}} deve conter {exactLength} dígitos.");
}