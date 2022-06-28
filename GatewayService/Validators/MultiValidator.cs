using System.Linq;

namespace GatewayService.Validators
{
    public static class MultiValidator<T>
    {
        private static readonly List<IValidator<T>> Validators;

        static MultiValidator()
        {
            if (Validators == null)
            {
                Validators = new List<IValidator<T>>();
            }

            if (Validators.Any()) return;
            Validators.AddRange(from validator in MultiValidatorBase.Validators
                                let type = validator.MakeGenericType(typeof(T))
                                let instance = Activator.CreateInstance(type)
                                select (IValidator<T>)instance);
        }

        public static async Task<bool> IsValid(T message)
        {
            var result = true;
            foreach (var validator in Validators)
            {
                if (!await validator.IsValid(message))
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
