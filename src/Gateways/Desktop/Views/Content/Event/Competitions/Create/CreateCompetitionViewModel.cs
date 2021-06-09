using EnduranceJudge.Application.Events.Commands.Competitions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.Competitions.Create
{
    public class CreateCompetitionViewModel : CreateFormBase<UpdateCompetition>
    {
        public CreateCompetitionViewModel(IApplicationService application) : base(application)
        {
        }
    }
}
