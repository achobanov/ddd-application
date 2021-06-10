using AutoMapper;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Participants;
using ImportParticipant = EnduranceJudge.Domain.Aggregates.Import.Participants.Participant;

namespace EnduranceJudge.Gateways.Persistence.Entities.ParticipantsInCompetitions
{
    public class ParticipantInCompetitionEntityMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            this.AddFromMaps(profile);
            this.AddToMaps(profile);
        }

        private void AddFromMaps(IProfileExpression profile)
        {
            profile.CreateMap<Participant, ParticipantInCompetition>()
                .ForMember(pic => pic.Id, opt => opt.Ignore())
                .ForMember(pic => pic.Competition, opt => opt.Ignore())
                .ForMember(pic => pic.CompetitionId, opt => opt.Ignore())
                .ForMember(pic => pic.ParticipantId, opt => opt.MapFrom(p => p.Id))
                .ForMember(pic => pic.Participant, opt => opt.MapFrom(p => p));

            profile.CreateMap<ImportParticipant, ParticipantInCompetition>()
                .ForMember(pic => pic.Id, opt => opt.Ignore())
                .ForMember(pic => pic.Competition, opt => opt.Ignore())
                .ForMember(pic => pic.CompetitionId, opt => opt.Ignore())
                .ForMember(pic => pic.ParticipantId, opt => opt.MapFrom(p => p.Id))
                .ForMember(pic => pic.Participant, opt => opt.MapFrom(p => p));
        }

        private void AddToMaps(IProfileExpression profile)
        {
            profile.CreateMap<ParticipantInCompetition, Participant>()
                .ForMember(p => p.Id, opt => opt.MapFrom(pic => pic.ParticipantId))
                .ForMember(p => p.ContestNumber, opt => opt.MapFrom(pic => pic.Participant.ContestNumber))
                .ForMember(p => p.MaxAverageSpeedInKpH, opt => opt.MapFrom(pic => pic.Participant.MaxAverageSpeedInKpH))
                .ForMember(p => p.RfId, opt => opt.MapFrom(pic => pic.Participant.RfId))
                .ForMember(p => p.Athlete, opt => opt.MapFrom(pic => pic.Participant.Athlete))
                .ForMember(p => p.Horse, opt => opt.MapFrom(pic => pic.Participant.Horse));

            profile.CreateMap<ParticipantInCompetition, ImportParticipant>()
                .ForMember(p => p.Id, opt => opt.MapFrom(pic => pic.ParticipantId))
                .ForMember(p => p.Athlete, opt => opt.MapFrom(pic => pic.Participant.Athlete))
                .ForMember(p => p.Horse, opt => opt.MapFrom(pic => pic.Participant.Horse));
        }
    }
}
