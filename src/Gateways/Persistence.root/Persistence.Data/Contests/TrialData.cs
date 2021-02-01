using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Trials;

namespace EnduranceContestManager.Gateways.Persistence.Data.Contests
{
    public class TrialData : DataEntry, ITrialState, IMapFrom<Trial>, IMapTo<Trial>
    {
        public int LengthInKilometers { get; }

        public int DurationInDays { get; }
    }
}
