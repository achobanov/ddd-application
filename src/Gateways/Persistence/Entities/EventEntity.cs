using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using ImportEvent = EnduranceJudge.Domain.Aggregates.Import.Events.Event;

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

            mapper.CreateMap<EventEntity, ImportEvent>()
                .EqualityComparison((entity, domain) => entity.Id == domain.Id)
                .ForMember(x => x.Competitions, opt => opt.MapFrom(y => y.Competitions));

            mapper.CreateMap<ImportEvent, EventEntity>()
                .EqualityComparison((domain, entity) => domain.Id == entity.Id);
        }
    }
}
