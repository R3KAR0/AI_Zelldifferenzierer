namespace LogServiceRequestMessages
{
    public interface GetLogsByDateBetween
    {
        string AdminId { get; }
        DateTime DateAfter { get; }
        DateTime DateBefore { get; }
    }
}
