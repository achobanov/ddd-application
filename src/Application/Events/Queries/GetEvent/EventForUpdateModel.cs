using AutoMapper;
using EnduranceJudge.Application.Events.Converters;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Application.Events.Queries.GetEvent
{
    public class EventForUpdateModel : IMapExplicitly
    {
        public string Name { get; set; }
        public string PopulatedPlace { get; set; }
        public string CountryIsoCode { get; set; }
        public string PresidentGroundJury { get; set; }
        public string PresidentVetCommission { get; set; }
        public string ForeignJudge { get; set; }
        public string FeiTechDelegate { get; set; }
        public string FeiVetDelegate { get; set; }
        public string ActiveVet { get; set; }
        public string MembersOfVetCommittee { get; set; }
        public string MembersOfJudgeCommittee { get; set; }
        public string Stewards { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<Event, EventForUpdateModel>()
                .ForMember(
                    d => d.PresidentGroundJury,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.PresidentGroundJury), s => s.Personnel))
                .ForMember(
                    d => d.PresidentVetCommission,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.PresidentVetCommission), s => s.Personnel))
                .ForMember(
                    d => d.ForeignJudge,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.ForeignJudge), s => s.Personnel))
                .ForMember(
                    d => d.FeiTechDelegate,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.FeiTechDelegate), s => s.Personnel))
                .ForMember(
                    d => d.FeiVetDelegate,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.FeiVetDelegate), s => s.Personnel))
                .ForMember(
                    d => d.ActiveVet,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.ActiveVet), s => s.Personnel))
                .ForMember(
                    d => d.MembersOfVetCommittee,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.MemberOfVetCommittee), s => s.Personnel))
                .ForMember(
                    d => d.MembersOfJudgeCommittee,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.MemberOfJudgeCommittee), s => s.Personnel))
                .ForMember(
                    d => d.Stewards,
                    opt => opt.ConvertUsing(
                        PersonnelConverter.New(PersonnelRole.Steward), s => s.Personnel));
        }
    }
}
