using EnduranceJudge.Gateways.Desktop.Core.Enums;
using Prism.Regions;

namespace EnduranceJudge.Gateways.Desktop.Core.Extensions
{
    public static class NavigationContextExtensions
    {
        public static int? GetId(this NavigationContext context)
        {
            var hasId = context.Parameters.TryGetValue<int>(DesktopConstants.EntityIdParameter, out var id);
            if (!hasId)
            {
                return null;
            }

            return id;
        }

        public static FormOperation GetOperationMode(this NavigationContext context)
        {
            var hasOperationParam = context.Parameters.TryGetValue<FormOperation>(
                DesktopConstants.OperationModeParameter,
                out var operation);

            if (!hasOperationParam)
            {
                return default;
            }

            return operation;
        }
    }
}
