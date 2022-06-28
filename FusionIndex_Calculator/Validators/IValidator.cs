namespace FusionIndex_Calculator.Validators
{
    public interface IValidator<in T>
    {
        Task<bool> IsValid(T message);
    }
}
