using Grpc.Core;
using server;

namespace server.Services
{
    public class LoginerService : Loginer.LoginerBase
    {
        private readonly ILogger<LoginerService> _logger;
        public LoginerService(ILogger<LoginerService> logger)
        {
            _logger = logger;
        }

        public override Task<LoginReply> AccountEnter(LoginRequest request, ServerCallContext context)
        {
            return Task.FromResult(new LoginReply
            {
                State = "服务端给的结果: " + request.Name
            });
        }
    }
}