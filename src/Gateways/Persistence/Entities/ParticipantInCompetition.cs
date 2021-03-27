using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.Participants;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class ParticipantInCompetition : EntityModel, IMapExplicitly
    {
        [JsonIgnore]
        public ParticipantEntity Participant { get; set; }
        public int ParticipantId { get; set; }

        [JsonIgnore]
        public CompetitionEntity Competition { get; set; }
        public int CompetitionId { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<ParticipantInCompetition, Participant>()
                .EqualityComparison((pic, p) => pic.ParticipantId == p.Id)
                .ForMember(p => p.Id, opt => opt.MapFrom(pic => pic.ParticipantId))
                .ForMember(p => p.ContestNumber, opt => opt.MapFrom(pic => pic.Participant.ContestNumber))
                .ForMember(p => p.MaxAverageSpeedInKpH, opt => opt.MapFrom(pic => pic.Participant.MaxAverageSpeedInKpH))
                .ForMember(p => p.RfId, opt => opt.MapFrom(pic => pic.Participant.RfId))
                .ForMember(p => p.Athlete, opt => opt.MapFrom(pic => pic.Participant.Athlete))
                .ForMember(p => p.Horse, opt => opt.MapFrom(pic => pic.Participant.Horse));

            // mapper.CreateMap<ParticipantInCompetition, Competition>()
            //     .EqualityComparison((pic, p) => pic.CompetitionId == p.Id)
            //     .ForMember(c => c.Id, opt => opt.MapFrom(pic => pic.CompetitionId))
            //     .ForMember(c => c.Type, opt => opt.MapFrom(pic => pic.Competition.Type))
            //     .ForMember(c => c.Phases, opt => opt.MapFrom(pic => pic.Competition.Phases))
            //     .ForMember(c => c.Event, opt => opt.MapFrom(pic => pic.Competition.Event));

            mapper.CreateMap<Participant, ParticipantInCompetition>()
                .EqualityComparison((p, pic) => pic.ParticipantId == p.Id)
                .ForMember(pic => pic.Id, opt => opt.Ignore())
                .ForMember(pic => pic.Competition, opt => opt.Ignore())
                .ForMember(pic => pic.CompetitionId, opt => opt.Ignore())
                .ForMember(pic => pic.ParticipantId, opt => opt.MapFrom(p => p.Id))
                .ForMember(pic => pic.Participant, opt => opt.MapFrom(p => p));
        }
    }
}
