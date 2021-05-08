using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Personnels;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class PersonnelEntity : EntityModel, IPersonnelState, IMap<Personnel>
    {
        public string Name { get; set; }
        public PersonnelRole Role { get; set; }

        [JsonIgnore]
        public EnduranceEventEntity EnduranceEvent { get; set; }
        public int EnduranceEventId { get; set; }
    }
}
