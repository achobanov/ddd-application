using AutoMapper;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Core.Mappings.Converters;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents
{
    public class EnduranceEventMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            this.AddFromMaps(profile);
            this.AddToMaps(profile);
        }

        private void AddFromMaps(IProfileExpression profile)
        {
            profile.CreateMap<EnduranceEventViewModel, SaveEnduranceEvent>()
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

        private void AddToMaps(IProfileExpression profile)
        {
            profile.CreateMap<EnduranceEventForUpdateModel, EnduranceEventViewModel>()
                .MapMember(d => d.SelectedCountryIsoCode, s => s.CountryIsoCode)
                .AfterMap((update, viewModel) => viewModel.UpdateListItems());
        }
    }
}
