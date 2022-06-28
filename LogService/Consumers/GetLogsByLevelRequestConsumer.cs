using LogService.Repositories;
using LogServiceRequests;
using LogServiceResponseMessages;
using LogServiceModels;
using MassTransit;
using Serilog;

namespace LogService.Consumers
{
    public class GetLogsByLevelRequestConsumer : IConsumer<GetLogsByLevelRequest>
    {
        private readonly LogServiceRepository _repository;

        public GetLogsByLevelRequestConsumer(LogServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<GetLogsByLevelRequest> context)
        {
            try
            {
                var res = _repository.GetLogsByLogLevel(context.Message.Level);
                await context.RespondAsync<LogListResponse>(res);
            }
            catch (Exception e)
            {
                Log.Error($"GetLogsByLevelRequestConsumer threw an exception! Exception: {e}");
            }

        }
    }
}
