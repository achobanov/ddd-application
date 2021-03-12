using EnduranceJudge.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnduranceJudge.Gateways.Persistence
{
    public static class PersistenceConstants
    {
        public const string BackupFileName = "backup.txt";

        public static Assembly[] Assemblies
        {
            get
            {
                var projectNames = ProjectUtilities
                    .GetConventionalProjectNames("Gateways.Persistence")
                    .Concat(new[] {"EnduranceJudge.Gateways.Persistence.Data"})
                    .ToArray();

                var assemblies = ReflectionUtilities.GetAssemblies(projectNames);

                return assemblies;
            }
        }

        public static class Types
        {
            public static readonly Type DbSet = typeof(DbSet<>);
            public static readonly Type List = typeof(List<>);
            public static readonly Type Action = typeof(Action<,>);
        }
    }
}
