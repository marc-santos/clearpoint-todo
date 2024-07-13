using FluentValidation;

namespace TodoList.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, Guid> ValidateId<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty();
        }
    }
}
