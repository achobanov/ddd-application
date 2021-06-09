using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Create;
using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Event.Personnels;
using System.Collections.Generic;

namespace EnduranceJudge.Application.Events.Services
{
    public interface IEnduranceEventService : IService
    {
        IEnumerable<Personnel> PreparePersonnel(CreateEnduranceEvent request);
    }
}
