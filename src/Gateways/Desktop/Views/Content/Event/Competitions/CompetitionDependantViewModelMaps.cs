﻿using AutoMapper;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Create.Models;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions
{
    public class CompetitionDependantViewModelMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            profile.CreateMap<CompetitionDependentViewModel, CreateCompetitionModel>()
                .MapMember(d => d.Type, s => (CompetitionType) s.Type);
        }
    }
}
