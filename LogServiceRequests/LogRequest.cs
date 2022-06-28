using LogServiceModels;

namespace LogServiceRequests
{
    public interface LogRequest
    {
        string LogMessage { get; }
        string Sender { get; }
        ELevel Level { get; }
    }
}
