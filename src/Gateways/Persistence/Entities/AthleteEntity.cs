using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Import.Athletes;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System;
using Athlete = EnduranceJudge.Domain.Aggregates.Event.Participants.Athlete;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class AthleteEntity : EntityModel, IAthleteState, IMapExplicitly
    {
        public string FeiId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Category Category { get; set; }

        [JsonIgnore]
        public ParticipantEntity Participant { get; set; }
        public int ParticipantId { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<AthleteEntity, Athlete>()
                .EqualityComparison((ae, a) => ae.Id == a.Id);

            mapper.CreateMap<Athlete, AthleteEntity>()
                .EqualityComparison((a, ae) => ae.Id == a.Id)
                .ForMember(x => x.ParticipantId, opt => opt.Condition(a => a.Participant != null))
                .ForMember(x => x.Participant, opt => opt.Condition(a => a.Participant != null));
        }
    }
}
