using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Participants;
using EnduranceJudge.Gateways.Persistence.Core;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class ParticipantEntity : EntityModel, IParticipantState, IMapExplicitly
    {
        public string RfId { get; set; }
        public int ContestNumber { get; set; }
        public int? MaxAverageSpeedInKpH { get; set; }

        [JsonIgnore]
        public HorseEntity Horse { get; set; }
        public int HorseId { get; set; }

        [JsonIgnore]
        public AthleteEntity Athlete { get; set; }
        public int AthleteId { get; set; }

        [JsonIgnore]
        public ICollection<CompetitionEntity> Competitions { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<ParticipantEntity, Participant>()
                .EqualityComparison((entity, personnel) => entity.Id == personnel.Id);

            mapper.CreateMap<Participant, ParticipantEntity>()
                .EqualityComparison((personnel, entity) => entity.Id == personnel.Id)
                .ForMember(x => x.HorseId, opt => opt.Ignore())
                .ForMember(x => x.Horse, opt => opt.Ignore())
                .ForMember(x => x.AthleteId, opt => opt.Ignore())
                .ForMember(x => x.Athlete, opt => opt.Ignore());
        }
    }
}
