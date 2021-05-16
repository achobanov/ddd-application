using EnduranceJudge.Core.Models;
using MediatR;

namespace EnduranceJudge.Application.Core.Requests
{
    public interface IIdentifiableRequest : IReIdentifiable, IRequest
    {
    }

    public interface IIdentifiableRequest<out T> : IReIdentifiable, IRequest<T>
    {
    }
}
