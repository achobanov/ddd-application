using AutoMapper;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Create;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Update;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Core.Mappings.Converters;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Create;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Update;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents
{
    public class EnduranceEventMappingProfile : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            this.CreateFormMaps(profile);
            this.UpdateFormMaps(profile);
        }

        private void CreateFormMaps(IProfileExpression profile)
        {
            profile.CreateMap<CreateEnduranceEventViewModel, CreateEnduranceEvent>()
                .MapMember(d => d.CountryIsoCode, s => s.SelectedCountryIsoCode)
                .ForMember(
                    dest => dest.MembersOfJudgeCommittee,
                    opt => opt.ConvertUsing(StringSplitter.New))
                .ForMember(
                    dest => dest.MembersOfVetCommittee,
                    opt => opt.ConvertUsing(StringSplitter.New))
                .ForMember(
                    dest => dest.Stewards,
                    opt => opt.ConvertUsing(StringSplitter.New));
        }

        private void UpdateFormMaps(IProfileExpression profile)
        {
            profile.CreateMap<UpdateEnduranceEventViewModel, UpdateEnduranceEvent>()
                .MapMember(d => d.CountryIsoCode, s => s.SelectedCountryIsoCode)
                .ForMember(
                    dest => dest.MembersOfJudgeCommittee,
                    opt => opt.ConvertUsing(StringSplitter.New))
                .ForMember(
                    dest => dest.MembersOfVetCommittee,
                    opt => opt.ConvertUsing(StringSplitter.New))
                .ForMember(
                    dest => dest.Stewards,
                    opt => opt.ConvertUsing(StringSplitter.New));

            profile.CreateMap<EnduranceEventForUpdateModel, UpdateEnduranceEventViewModel>()
                .MapMember(d => d.SelectedCountryIsoCode, s => s.CountryIsoCode);
        }
    }
}
