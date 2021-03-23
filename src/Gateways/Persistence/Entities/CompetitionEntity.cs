using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class CompetitionEntity
        : EntityModel,
        ICompetitionState,
        IMapExplicitly
    {
        public CompetitionType Type { get; set; }

        public int EventId { get; set; }

        [JsonIgnore]
        public EventEntity Event { get; set; }

        [JsonIgnore]
        public IList<PhaseEntity> Phases { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<CompetitionEntity, Competition>()
                .EqualityComparison((entity, domain) => entity.Id == domain.Id);

            mapper.CreateMap<Competition, CompetitionEntity>()
                .EqualityComparison((domain, entity) => entity.Id == domain.Id)
                .ForMember(x => x.EventId, opt => opt.Ignore())
                .ForMember(x => x.Event, opt => opt.Ignore());
        }
    }
}
