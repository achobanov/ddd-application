using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Phases;

namespace EnduranceContestManager.Gateways.Persistence.Stores
{
    public class FinalPhaseStore : PhaseStore, IMapFrom<FinalPhase>, IMapTo<FinalPhase>
    {
    }
}
