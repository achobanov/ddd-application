using MediatR;

namespace EnduranceJudge.Application.Core.Requests
{
    public interface IIdentifiableRequest : IRequest
    {
        public int Id { get; }
    }
}
