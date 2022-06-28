using UserServiceModels;

namespace UserServiceResponseMessages
{
    public interface GetOneUserResponse
    {
        ApplicationUser User { get; }
    }
}
