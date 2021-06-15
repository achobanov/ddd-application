﻿using AutoMapper;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions
{
    public class CompetitionDependantViewModelMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            profile.CreateMap<CompetitionDependantViewModel, CompetitionDependantModel>()
                .MapMember(d => d.Type, s => (CompetitionType)s.CompetitionType);

            profile.CreateMap<CompetitionDependantModel, CompetitionDependantViewModel>()
                .MapMember(d => d.CompetitionType, s => (int)s.Type);

            profile.CreateMap<CompetitionDependantViewModel, CompetitionDependantViewModel>()
                .MapMember(d => d.CompetitionType, s => s.CompetitionType);
        }
    }
}
