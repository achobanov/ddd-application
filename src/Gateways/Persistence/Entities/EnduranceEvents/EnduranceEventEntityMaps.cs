using AutoMapper;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Converters;

namespace EnduranceJudge.Gateways.Persistence.Entities.EnduranceEvents
{
    public class EnduranceEventEntityMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            this.AddFromMaps(profile);
            this.AddToMaps(profile);
        }

        private void AddFromMaps(IProfileExpression profile)
        {
            profile.CreateMap<EnduranceEvent, EnduranceEventEntity>()
                .ForMember(d => d.Country, opt => opt.Ignore());
        }

        private void AddToMaps(IProfileExpression profile)
        {
            profile.CreateMap<EnduranceEventEntity, EnduranceEventForUpdateModel>()
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
