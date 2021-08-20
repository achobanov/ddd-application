﻿using AutoMapper;
using EnduranceJudge.Application.Events.Models;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Roots.Athletes
{
    public class AthleteViewModelMaps : ICustomMapConfiguration
    {
        public void AddFromMaps(IProfileExpression profile)
        {
            profile.CreateMap<AthleteRootModel, AthleteViewModel>()
                .MapMember(x => x.CountryItems, y => y.Countries)
                .MapMember(x => x.CategoryId, y => (int)y.Category);
        }

        public void AddToMaps(IProfileExpression profile)
        {
        }
    }
}
