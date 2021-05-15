using AutoMapper;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Converters;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class EnduranceEventEntity : EntityModel, IEnduranceEventState,
        IMap<EnduranceEvent>,
        IMap<Domain.Aggregates.Import.EnduranceEvents.EnduranceEvent>,
        IMapTo<ListItemModel>,
        IMapExplicitly
    {
        public string Name { get; set; }

        public string PopulatedPlace { get; set; }

        [JsonIgnore]
        public IList<CompetitionEntity> Competitions { get; set; }

        [JsonIgnore]
        public IList<PersonnelEntity> Personnel { get; set; }

        [JsonIgnore]
        public CountryEntity Country { get; set; }
        public string CountryIsoCode { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<EnduranceEvent, EnduranceEventEntity>()
                .ForMember(d => d.Country, opt => opt.Ignore());

            mapper.CreateMap<EnduranceEventEntity, EnduranceEventForUpdateModel>()
                .ForMember(
                    d => d.PresidentGroundJury,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.PresidentGroundJury),
                         s => s.Personnel))
                .ForMember(
                    d => d.PresidentVetCommission,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.PresidentVetCommission),
                        s => s.Personnel))
                .ForMember(
                    d => d.ForeignJudge,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.ForeignJudge),
                        s => s.Personnel))
                .ForMember(
                    d => d.FeiTechDelegate,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.FeiTechDelegate),
                        s => s.Personnel))
                .ForMember(
                    d => d.FeiVetDelegate,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.FeiVetDelegate),
                        s => s.Personnel))
                .ForMember(
                    d => d.ActiveVet,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.ActiveVet),
                        s => s.Personnel))
                .ForMember(
                    d => d.MembersOfVetCommittee,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.MemberOfVetCommittee),
                        s => s.Personnel))
                .ForMember(
                    d => d.MembersOfJudgeCommittee,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.MemberOfJudgeCommittee),
                        s => s.Personnel))
                .ForMember(
                    d => d.Stewards,
                    opt => opt.ConvertUsing(
                        new PersonnelConverter(PersonnelRole.Steward),
                        s => s.Personnel));
        }
    }
}
