using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Events;

namespace EnduranceJudge.Application.Events.Factories
{
    public interface IEventFactory : IService
    {
        Event Create(IEventState state);
    }
}
