using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class EventEntity : EntityModel, IEventState, IMapExplicitly
    {
        public string Name { get; set; }

        public string PopulatedPlace { get; set; }

        [JsonIgnore]
        public IList<CompetitionEntity> Competitions { get; set; }

        [JsonIgnore]
        public IList<PersonnelEntity> Personnel { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<EventEntity, Event>()
                .EqualityComparison((entity, domain) => entity.Id == domain.Id);

            mapper.CreateMap<Event, EventEntity>()
                .EqualityComparison((domain, entity) => domain.Id == entity.Id);
        }
    }
}
