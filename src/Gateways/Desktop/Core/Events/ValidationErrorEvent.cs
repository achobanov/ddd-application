using EnduranceJudge.Core.Enums;
using Prism.Events;

namespace EnduranceJudge.Gateways.Desktop.Core.Events
{
    public class ValidationErrorEvent : PubSubEvent<string>
    {
        public NotificationSeverity Severity => NotificationSeverity.Warning;
    }
}
