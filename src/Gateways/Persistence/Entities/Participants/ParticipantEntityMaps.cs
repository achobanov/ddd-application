using AutoMapper;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Participants;
using ImportParticipant = EnduranceJudge.Domain.Aggregates.Import.Participants.Participant;

namespace EnduranceJudge.Gateways.Persistence.Entities.Participants
{
    public class ParticipantEntityMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            this.AddFromMaps(profile);
            this.AddToMaps(profile);
        }

        private void AddFromMaps(IProfileExpression profile)
        {
            profile.CreateMap<Participant, ParticipantEntity>()
                .ForMember(x => x.HorseId, opt => opt.Condition(p => p.Horse != null))
                .ForMember(x => x.Horse, opt => opt.Condition(p => p.Horse != null))
                .ForMember(x => x.AthleteId, opt => opt.Condition(p => p.Athlete != null))
                .ForMember(x => x.Athlete, opt => opt.Condition(p => p.Athlete != null));

            profile.CreateMap<ImportParticipant, ParticipantEntity>()
                .ForMember(x => x.HorseId, opt => opt.Condition(p => p.Horse != null))
                .ForMember(x => x.Horse, opt => opt.Condition(p => p.Horse != null))
                .ForMember(x => x.AthleteId, opt => opt.Condition(p => p.Athlete != null))
                .ForMember(x => x.Athlete, opt => opt.Condition(p => p.Athlete != null));
        }

        private void AddToMaps(IProfileExpression profile)
        {
            profile.CreateMap<ParticipantEntity, Participant>();
            profile.CreateMap<ParticipantEntity, ImportParticipant>();
        }
    }
}
