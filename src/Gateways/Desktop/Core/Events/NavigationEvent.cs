using Prism.Events;

namespace EnduranceJudge.Gateways.Desktop.Core.Events
{
    public class NavigationEvent : PubSubEvent<IView>
    {
    }

    public class NavigationEvent<TParameter> : PubSubEvent<(IView, TParameter)>
    {
    }
}
