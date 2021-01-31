using MediatR;

namespace EnduranceContestManager.Application.Core.Requests
{
    public interface IIdentifiableRequest : IRequest
    {
        public int Id { get; }
    }
}
