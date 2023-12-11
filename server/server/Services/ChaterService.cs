using Grpc.Core;
using server;

namespace server.Services
{
    public class ChaterService : Chater.ChaterBase
    {
        private readonly ILogger<ChaterService> _logger;
        public ChaterService(ILogger<ChaterService> logger)
        {
            _logger = logger;
        }

        public override Task<BroadReply> BroadAll(SendMSGRequest request, ServerCallContext context)
        {
            return Task.FromResult(new BroadReply
            {              
                Name= "服务端接收到:"+request.Name,
                Content = "广播给所有人:" + request.Content,
            });
        }

        public override Task<SendPersonReply>SendToPerson(SendPersonRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SendPersonReply
            {
                State = 1        
            });
        }
    }
}