using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Gateways.Desktop.Core;
using System;

namespace EnduranceJudge.Gateways.Desktop.Services
{
    public interface INavigationService : ISingletonService
    {
        void NavigateToImport();

        void NavigateToEvent();

        void ChangeTo<T>(string regionName)
            where T : IView;

        void ChangeTo<T>(string regionName, int id)
            where T : IView;

        void ChangeTo(string regionName, Type viewType);

        void ChangeTo(string regionName, Type viewType, int id);
    }
}
