using LogServiceModels;

namespace LogServiceResponseMessages
{
    public interface LogListResponse
    {
        List<LogEntry> Entries { get; }
    }
}
