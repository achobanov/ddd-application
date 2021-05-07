using EnduranceJudge.Gateways.Desktop.Core;
using MediatR;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.FirstPage
{
    public class FirstViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        public FirstViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public string Heading { get; } = "First View Heading";
    }
}
