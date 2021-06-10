using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities.Competitions;
using EnduranceJudge.Gateways.Persistence.Entities.Participants;
using Newtonsoft.Json;
using ImportParticipant = EnduranceJudge.Domain.Aggregates.Import.Participants.Participant;

namespace EnduranceJudge.Gateways.Persistence.Entities.ParticipantsInCompetitions
{
    public class ParticipantInCompetition : EntityModel
    {
        [JsonIgnore]
        public ParticipantEntity Participant { get; set; }
        public int ParticipantId { get; set; }

        [JsonIgnore]
        public CompetitionEntity Competition { get; set; }
        public int CompetitionId { get; set; }
    }
}
