using MassTransit;
using UserServiceRequestMessages;

namespace UserService.Consumers
{
    public class UpdateUserRequestConsumer : IConsumer<UpdateUserRequest>
    {
        public Task Consume(ConsumeContext<UpdateUserRequest> context)
        {
            throw new NotImplementedException();
        }
    }
}
