using MediatR;

namespace EnduranceJudge.Application.Core.Requests
{
    public interface IIdentifiable
    {
        int Id { get; set; }
    }

    public interface IIdentifiableRequest : IIdentifiable, IRequest
    {
    }

    public interface IIdentifiableRequest<out T> : IIdentifiable, IRequest<T>
    {
    }
}
