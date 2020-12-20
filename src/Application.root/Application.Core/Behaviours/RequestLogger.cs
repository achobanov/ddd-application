using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace EnduranceContestManager.Application.Core.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger logger;

        public RequestLogger(ILogger logger)
            => this.logger = logger;

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            this.logger.LogInformation(
                "EnduranceContestManager Request: {Name} {@Request}",
                requestName,
                request);

            return Task.CompletedTask;
        }
    }
}
