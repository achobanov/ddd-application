using Prism.Regions;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core.Services.Implementations
{
    public class NavigationServiceBase
    {
        private static readonly Type ViewType = typeof(IView);

        private readonly IRegionManager regionManager;

        protected NavigationServiceBase(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        protected void ChangeTo<T>(string regionName) where T : IView
        {
            this.ChangeTo(regionName, typeof(T));
        }

        protected void ChangeTo<T>(string regionName, int id) where T : IView
        {
            this.ChangeTo(regionName, typeof(T), id);
        }

        public void ChangeTo<T>() where T : IView
        {
            this.ChangeTo(Regions.Content, typeof(T));
        }

        public void ChangeTo<T>(int id) where T : IView
        {
            this.ChangeTo(Regions.Content, typeof(T), id);
        }

        public void ChangeTo<T>(object data) where T : IView
        {
            this.ChangeTo(Regions.Content, typeof(T), data);
        }

        private void ChangeTo(string regionName, Type viewType, int id)
        {
            var parameters = new NavigationParameters
            {
                { DesktopConstants.EntityIdParameter, id },
            };

            this.ChangeTo(viewType, regionName, parameters);
        }

        private void ChangeTo(string regionName, Type viewType, object data)
        {
            var parameters = new NavigationParameters
            {
                { DesktopConstants.DataParameter, data },
            };

            this.ChangeTo(viewType, regionName, parameters);
        }

        protected void ChangeTo(string regionName, Type viewType)
        {
            this.ChangeTo(viewType, regionName, null);
        }

        protected void ChangeTo(Type viewType, string regionName, NavigationParameters parameters)
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
    }
}
