using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using Prism.Events;

namespace EnduranceJudge.Gateways.Desktop.Core.Events
{
    public class FormCreateEvent<T> : PubSubEvent<T>
        where T : DependantFormBase
    {
    }
}
