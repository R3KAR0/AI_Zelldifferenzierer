using UserServiceModels;

namespace UserServiceRequestMessages
{
    public interface CreateAdminRequest
    {
        string Title { get; }

        string Firstname { get; }

        string Lastname { get; }

        string IdentificationNumber { get; }

        string Email { get; }

        string Password { get; }

        UserType UserType { get; }
    }
}
