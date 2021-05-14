using EnduranceJudge.Gateways.Desktop.Core.Events;
using Prism.Events;
using Prism.Regions;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core.Services.Implementations
{
    public abstract class NavigationServiceBase
    {
        private static readonly Type ViewType = typeof(IView);

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        protected NavigationServiceBase(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;

            this.Subscribe();
        }

        public void ChangeTo<T>(string regionName) where T : IView
        {
            this.ChangeTo(regionName, typeof(T));
        }

        public void ChangeTo<T>(string regionName, int id) where T : IView
        {
            this.ChangeTo(regionName, typeof(T), id);
        }

        public void ChangeTo(string regionName, Type viewType, int id)
        {
            var parameters = new NavigationParameters
            {
                { DesktopConstants.NavigationIdKey, id },
            };

            this.ChangeTo(viewType, regionName, parameters);
        }

        public void ChangeTo(string regionName, Type viewType)
        {
            this.ChangeTo(viewType, regionName, null);
        }

        public void ChangeTo(Type viewType, string regionName, NavigationParameters parameters)
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
            this.regionManager.RequestNavigate(regionName, viewName, parameters);
        }

        protected void ClearRegion(string name)
        {
            var region = this.regionManager.Regions[name];
            region.RemoveAll();
        }

        private void Subscribe()
        {
            var regionName = Regions.Content;

            this.eventAggregator
                .GetEvent<ChangeRegionEvent>()
                .Subscribe(view => this.ChangeTo(regionName, view.GetType()));

            this.eventAggregator
                .GetEvent<ChangeRegionEvent<int>>()
                .Subscribe(tuple =>
                {
                    var (view, parameter) = tuple;
                    this.ChangeTo(regionName, view.GetType(), parameter);
                });
        }
    }
}
