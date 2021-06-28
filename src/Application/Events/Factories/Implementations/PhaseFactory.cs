using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Domain.Aggregates.Event.Phases;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class PhaseFactory : IPhaseFactory
     {
         public Phase Create(PhaseDependantModel data)
         {
             var phase = new Phase(data);
             return phase;
         }
     }
}
