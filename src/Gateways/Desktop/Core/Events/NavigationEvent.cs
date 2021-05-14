using Prism.Events;

namespace EnduranceJudge.Gateways.Desktop.Core.Events
{
    public class ChangeRegionEvent : PubSubEvent<IView>
    {
    }

    public class ChangeRegionEvent<TParameter> : PubSubEvent<(IView, TParameter)>
    {
    }
}
