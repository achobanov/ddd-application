using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Gateways.Desktop.Core;

namespace EnduranceJudge.Gateways.Desktop.Services
{
    public interface INavigationService : ISingletonService
    {
        void NavigateToImport();

        void NavigateToEvent();

        void ChangeTo<T>()
            where T : IView;

        void ChangeTo<T>(int id)
            where T : IView;

        void ChangeTo<T>(object data)
            where T : IView;
    }
}
