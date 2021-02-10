using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceContestManager.Gateways.Persistence.Stores.Contests
{
    // TODO: Do I need **Data classes?
    public class TrialData : DataEntry, ITrialState, IMapFrom<Trial>, IMapTo<Trial>
    {
        public TrialData()
        {
        }

        [JsonConstructor]
        public TrialData(int id, int lengthInKilometers, int durationInDays, int contestId)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.DurationInDays = durationInDays;
            this.ContestId = contestId;
        }

        public int LengthInKilometers { get; internal set; }

        public int DurationInDays { get; internal set; }

        public int ContestId { get; internal set; }

        [JsonIgnore]
        public ContestData Contest { get; internal set; }
    }
}
