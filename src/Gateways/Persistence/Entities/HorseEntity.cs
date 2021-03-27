using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Import.Horses;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System;
using Horse = EnduranceJudge.Domain.Aggregates.Event.Participants.Horse;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class HorseEntity : EntityModel, IHorseState, IMapExplicitly
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public bool IsStallion { get; set; }
        public DateTime BirthDay { get; set; }
        public string Owner { get; set; }

        [JsonIgnore]
        public ParticipantEntity Participant { get; set; }
        public int ParticipantId { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<HorseEntity, Horse>()
                .EqualityComparison((entity, horse) => entity.Id == horse.Id);

            mapper.CreateMap<Horse, HorseEntity>()
                .EqualityComparison((horse, entity) => entity.Id == horse.Id)
                .ForMember(x => x.ParticipantId, opt => opt.Condition(e => e.Participant != null))
                .ForMember(x => x.Participant, opt => opt.Condition(e => e.Participant != null));
        }
    }
}
