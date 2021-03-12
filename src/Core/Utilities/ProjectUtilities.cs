namespace EnduranceJudge.Core.Utilities
{
    public static class ProjectUtilities
    {
        public static string[] GetConventionalProjectNames(string project)
            => new[]
            {
                string.Format(CoreConstants.ProjectNameTemplate, project),
                string.Format(CoreConstants.CoreProjectNameTemplate, project),
            };
    }
}
