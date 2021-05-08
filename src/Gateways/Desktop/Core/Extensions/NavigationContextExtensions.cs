using Prism.Regions;

namespace EnduranceJudge.Gateways.Desktop.Core.Extensions
{
    public static class NavigationContextExtensions
    {
        public static int? GetId(this NavigationContext context)
        {
            var hasId = context.Parameters.TryGetValue<int>(DesktopConstants.NavigationIdKey, out var id);
            if (!hasId)
            {
                return null;
            }

            return id;
        }
    }
}
