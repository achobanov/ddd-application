using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Events;
using Prism.Events;
using Prism.Regions;
using System;

namespace EnduranceJudge.Gateways.Desktop.Services.Implementations
{
    public class NavigationService : INavigationService
    {
        private static readonly Type ViewType = typeof(IView);

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public NavigationService(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;

            this.Subscribe();
        }

        public void NavigateTo<T>() where T : IView
        {
            this.NavigateTo(typeof(T));
        }

        public void NavigateTo<T>(int id) where T : IView
        {
            this.NavigateTo(typeof(T), id);
        }

        public void NavigateTo(Type viewType, int id)
        {
            var parameters = new NavigationParameters
            {
                { DesktopConstants.NavigationIdKey, id },
            };

            this.NavigateTo(viewType, parameters);
        }

        public void NavigateTo(Type viewType)
        {
            this.NavigateTo(viewType, null);
        }

        public void NavigateTo(Type viewType, NavigationParameters parameters)
        {
            if (viewType == null)
            {
                throw new ArgumentNullException(nameof(viewType));
            }

            if (!ViewType.IsAssignableFrom(viewType))
            {
                throw new InvalidOperationException($"Type '{viewType?.Name}' does not implement '{ViewType}'");
            }

            var viewName = viewType.Name;
            this.regionManager.RequestNavigate(Regions.Content, viewName, parameters);
        }

        private void Subscribe()
        {
            this.eventAggregator
                .GetEvent<NavigationEvent>()
                .Subscribe(view => this.NavigateTo(view.GetType()));

            this.eventAggregator
                .GetEvent<NavigationEvent<int>>()
                .Subscribe(tuple => this.NavigateTo(tuple.Item1.GetType(), tuple.Item2));
        }
    }
}
