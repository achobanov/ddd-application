using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Gateways.Desktop.Core;
using System;

namespace EnduranceJudge.Gateways.Desktop.Services
{
    public interface INavigationService : ISingletonService
    {
        void NavigateTo<T>()
            where T : IView;

        void NavigateTo(Type viewType);
    }
}
