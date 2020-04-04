namespace Blog.Application.Common.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public abstract class Handler<TRequest> : AsyncRequestHandler<TRequest> where TRequest : IRequest
    {
    }

    public abstract class Handler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        public virtual Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
            => throw new System.NotImplementedException();
    }
}
