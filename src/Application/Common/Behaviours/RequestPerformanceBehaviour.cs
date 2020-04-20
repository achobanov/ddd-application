namespace Blog.Application.Common.Behaviours
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Blog.Application.Contracts;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;
        private readonly IAuthenticationContext authenticationContext;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger, IAuthenticationContext authenticationContext)
        {
            this.timer = new Stopwatch();
            
            this.logger = logger;
            this.authenticationContext = authenticationContext;
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
            var username = this.authenticationContext.Username;

            this.logger.LogWarning(
                "Blog Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Username} {@Request}",
                requestName, 
                elapsedMilliseconds, 
                username ?? "Anonymous",
                request);

            return response;
        }
    }
}
