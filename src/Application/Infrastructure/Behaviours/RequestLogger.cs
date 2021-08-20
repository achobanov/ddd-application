﻿using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Contracts;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Blog.Application.Infrastructure.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger logger;
        private readonly IAuthenticationContext authenticationContext;

        public RequestLogger(
            ILogger<TRequest> logger, 
            IAuthenticationContext authenticationContext)
        {
            this.logger = logger;
            this.authenticationContext = authenticationContext;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var username = this.authenticationContext.Username;

            this.logger.LogInformation(
                "Blog Request: {Name} {@UserName} {@Request}",
                requestName,
                username ?? "Anonymous",
                request);

            return Task.CompletedTask;
        }
    }
}
