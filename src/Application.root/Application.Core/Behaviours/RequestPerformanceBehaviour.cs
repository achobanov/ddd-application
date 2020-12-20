using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using EnduranceContestManager.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnduranceContestManager.Application.Core.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            this.timer = new Stopwatch();
            
            this.logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            this.timer.Start();

            var response = await next();

            this.timer.Stop();

            var elapsedMilliseconds = this.timer.ElapsedMilliseconds;

            if (elapsedMilliseconds <= 500)
            {
                return response;
            }

            var requestName = typeof(TRequest).Name;

            this.logger.LogWarning(
                "EnduranceContestManager Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                requestName, 
                elapsedMilliseconds, 
                request);

            return response;
        }
    }
}
