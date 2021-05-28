using AutoMapper;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ImportCompetition = EnduranceJudge.Domain.Aggregates.Import.Competitions.Competition;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class CompetitionEntity : EntityModel, ICompetitionState, IMapExplicitly
    {
        public CompetitionType Type { get; set; }

        [JsonIgnore]
        public EnduranceEventEntity EnduranceEvent { get; set; }
        public int EnduranceEventId { get; set; }

        [JsonIgnore]
        public IList<PhaseEntity> Phases { get; set; }

        [JsonIgnore]
        public IList<ParticipantInCompetition> ParticipantsInCompetitions { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<CompetitionEntity, Competition>()
                .ForMember(c => c.Participants, opt => opt.MapFrom(ce => ce.ParticipantsInCompetitions));

            mapper.CreateMap<Competition, CompetitionEntity>()
                .ForMember(ce => ce.ParticipantsInCompetitions, opt => opt.MapFrom(c => c.Participants))
                .AfterMap((c, ce) =>
                {
                    foreach (var participantInCompetition in ce.ParticipantsInCompetitions
                        .Where(pic => pic.CompetitionId == default))
                    {
                        participantInCompetition.Competition = this;
                        participantInCompetition.CompetitionId = this.Id;
                    }
                });

            mapper.CreateMap<CompetitionEntity, ImportCompetition>()
                .ForMember(c => c.Participants, opt => opt.MapFrom(ce => ce.ParticipantsInCompetitions));

            mapper.CreateMap<ImportCompetition, CompetitionEntity>()
                .ForMember(ce => ce.ParticipantsInCompetitions, opt => opt.MapFrom(c => c.Participants))
                .AfterMap((c, ce) =>
                {
                    foreach (var participantInCompetition in ce.ParticipantsInCompetitions
                        .Where(pic => pic.CompetitionId == default))
                    {
                        participantInCompetition.Competition = this;
                        participantInCompetition.CompetitionId = this.Id;
                    }
                });

            mapper.CreateMap<CompetitionEntity, ListItemModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Type.ToString()));
        }
    }
}
