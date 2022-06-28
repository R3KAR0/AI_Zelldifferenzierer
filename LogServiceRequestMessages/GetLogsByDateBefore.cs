namespace LogServiceRequestMessages
{
    public interface GetLogsByDateBefore
    {
        string AdminId { get; }
        DateTime Date { get; }
    }
}
