using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Blog.Common.Mappings
{
    public static class MappingApi
    {
        #region AutoMapper configuration
        
        private static IConfigurationProvider ConfigurationProvider;

        public static void Configure(IConfigurationProvider configurationProvider)
            => ConfigurationProvider = configurationProvider;

        #endregion

        public static IQueryable<TDestination> MapCollection<TDestination>(this IQueryable source)
            => source.ProjectTo<TDestination>(ConfigurationProvider);

    }
}
