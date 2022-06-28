using FusionIndex_Calculator.Validators;

namespace FusionIndex_Calculator.Extensions
{
    public static class Extensions
    {
        public static Task<bool> IsValid<T>(this T obj) => MultiValidator<T>.IsValid(obj);
    }
}
