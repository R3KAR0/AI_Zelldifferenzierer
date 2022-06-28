using LogServiceModels;

namespace LogServiceRequestMessages
{
    public interface GetLogsByLevelRequest
    {
        string AdminId { get; }
        ELevel Level { get; }
    }
}
