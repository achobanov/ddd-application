using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class PersonnelEntity : EntityModel, IPersonnelState, IMapExplicitly
    {
        public string Name { get; set; }

        [JsonIgnore]
        public EventEntity Event { get; set; }
        public int EventId { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<PersonnelEntity, Personnel>()
                .EqualityComparison((entity, personnel) => entity.Id == personnel.Id);

            mapper.CreateMap<Personnel, PersonnelEntity>()
                .EqualityComparison((personnel, entity) => entity.Id == personnel.Id)
                .ForMember(x => x.EventId, opt => opt.Ignore())
                .ForMember(x => x.Event, opt => opt.Ignore());
        }
    }
}
