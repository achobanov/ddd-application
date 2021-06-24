﻿using AutoMapper;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;

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
                .MapMember(d => d.CountryIsoCode, s => s.SelectedCountryIsoCode);
        }

        private void AddToMaps(IProfileExpression profile)
        {
            profile.CreateMap<EnduranceEventForUpdateModel, EnduranceEventViewModel>()
                .MapMember(d => d.SelectedCountryIsoCode, s => s.CountryIsoCode)
                .MapMember(d => d.Personnel, s => s.Personnel)
                .AfterMap((update, viewModel) =>
                {
                    viewModel.UpdateCompetitionItems();
                    viewModel.UpdatePersonnelItems();
                });
        }
    }
}
