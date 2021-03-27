using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class PersonnelEntity : EntityModel, IPersonnelState, IMapExplicitly
    {
        public string Name { get; set; }
        public PersonnelRole Role { get; }

        [JsonIgnore]
        public EventEntity Event { get; set; }
        public int EventId { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<PersonnelEntity, Personnel>()
                .EqualityComparison((entity, personnel) => entity.Id == personnel.Id);

            mapper.CreateMap<Personnel, PersonnelEntity>()
                .EqualityComparison((personnel, entity) => entity.Id == personnel.Id)
                .ForMember(x => x.EventId, opt => opt.Condition(p => p.Event != null))
                .ForMember(x => x.Event, opt => opt.Condition(p => p.Event != null));
        }
    }
}
