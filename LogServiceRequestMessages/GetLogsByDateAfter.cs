namespace LogServiceRequestMessages
{
    public interface GetLogsByDateAfter
    {
        string AdminId { get; }
        DateTime Date { get; }
    }
}
