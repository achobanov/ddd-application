using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Trials;
using Newtonsoft.Json;

namespace EnduranceContestManager.Gateways.Persistence.Data.Contests
{
    // TODO: Do I need **Data classes?
    public class TrialData : DataEntry, ITrialState, IMapFrom<Trial>, IMapTo<Trial>
    {
        public TrialData()
        {
        }

        [JsonConstructor]
        public TrialData(int id, int lengthInKilometers, int durationInDays)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.DurationInDays = durationInDays;
        }

        public int LengthInKilometers { get; internal set; }

        public int DurationInDays { get; internal set; }

        public int ContestDataId { get; set; }

        [JsonIgnore]
        public ContestData Contest { get; set; }
    }
}
