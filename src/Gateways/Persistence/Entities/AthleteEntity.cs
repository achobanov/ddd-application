using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Import.Athletes;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using Athlete = EnduranceJudge.Domain.Aggregates.Event.Participants.Athlete;
using ImportAthlete = EnduranceJudge.Domain.Aggregates.Import.Athletes.Athlete;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class AthleteEntity : EntityModel, IAthleteState,
        IMap<Athlete>,
        IMap<ImportAthlete>
    {
        public string FeiId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Category Category { get; set; }

        [JsonIgnore]
        public ParticipantEntity Participant { get; set; }
        public int ParticipantId { get; set; }

        [JsonIgnore]
        public CountryEntity Country { get; set; }
        public string CountryIsoCode { get; set; }
    }
}
