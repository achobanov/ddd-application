using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class CompetitionEntity : EntityModel, ICompetitionState, IMapExplicitly
    {
        public CompetitionType Type { get; set; }

        [JsonIgnore]
        public EventEntity Event { get; set; }
        public int EventId { get; set; }

        [JsonIgnore]
        public IList<PhaseEntity> Phases { get; set; }

        [JsonIgnore]
        public IList<ParticipantInCompetition> ParticipantsInCompetitions { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<CompetitionEntity, Competition>()
                .EqualityComparison((entity, domain) => entity.Id == domain.Id)
                .ForMember(c => c.Participants, opt => opt.MapFrom(ce => ce.ParticipantsInCompetitions));

            mapper.CreateMap<Competition, CompetitionEntity>()
                .EqualityComparison((domain, entity) => entity.Id == domain.Id)
                .ForMember(x => x.EventId, opt => opt.Condition(c => c.Event != null))
                .ForMember(x => x.Event, opt => opt.Condition(c => c.Event != null))
                .ForMember(ce => ce.ParticipantsInCompetitions, opt => opt.MapFrom(c => c.Participants))
                .AfterMap((c, ce) =>
                {
                    foreach (var participantInCompetition in ce.ParticipantsInCompetitions
                        .Where(pic => pic.CompetitionId == default))
                    {
                        participantInCompetition.Competition = this;
                        participantInCompetition.CompetitionId = this.Id;
                    }
                });
        }
    }
}
