using FluentValidation;

namespace FusionIndex_Calculator.Validators
{
    public class SqlInjectionValidator<T> : AbstractValidator<T>
    {
        public SqlInjectionValidator()
        {
            var stringProperties = typeof(T).GetProperties()
                .Where(prop => prop.PropertyType == typeof(string))
                .ToList();

            foreach (var stringProperty in stringProperties)
            {
                RuleFor(prop => stringProperty.GetValue(prop))
                    .Must(value => value == null ||
                               !new[] { "SELECT", "UPDATE", "INSERT", "DELETE", "CREATE", "DROP", "ALTER", ";" }
                                   .Any(str => value.ToString()
                                       .ToUpper()
                                       .Contains(str)));
            }
        }

        public async Task<bool> IsValid(T message)
        {
            return (await ValidateAsync(message)).IsValid;
        }
    }
}
