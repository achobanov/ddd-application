﻿using System.Reflection;
using EnduranceContestManager.Core.Mappings;

namespace EnduranceContestManager.Application
{
    public class ApplicationMappingProfile : MappingProfile
    {
        protected override Assembly[] Assemblies => new[] { Assembly.GetExecutingAssembly() };
    }
}
