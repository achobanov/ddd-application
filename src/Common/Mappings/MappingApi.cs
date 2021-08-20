using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Blog.Common.Mappings
{
    public static class MappingApi
    {
        public static TDestination Map<TDestination>(this object source)
        {
            ValidateConfiguration();

            return Mapper.Map<TDestination>(source);
        }

        public static async Task<TDestination> Map<TDestination>(this Task source)
        {
            ValidateConfiguration();

            var value = await (dynamic)source;

            return Mapper.Map<TDestination>(value);
        }

        public static IEnumerable<TDestination> MapCollection<TDestination>(this IEnumerable source)
        {
            ValidateConfiguration();

            return Mapper.Map<IEnumerable<TDestination>>(source);
        }

        public static IQueryable<TDestination> MapCollection<TDestination>(this IQueryable source)
        {
            ValidateConfiguration();

            return source.ProjectTo<TDestination>(Mapper.ConfigurationProvider);
        }

        public static async Task<IEnumerable<TDestination>> MapCollection<TDestination>(this Task source)
        {
            var value = (await (dynamic)source);
            if (value is IEnumerable enumerable)
            {
                return Mapper.Map<IEnumerable<TDestination>>(enumerable);
            }

            throw new ArgumentException(
                "Cannot map collection - argument value is not 'IEnumerable'.",
                nameof(source));
        }

        #region AutoMapper configuration

        public const string NotConfiguredMessage =
            "MappingApi is not configured. Make sure 'MappingApi.Configure' is called on application startup";

        private static IMapper Mapper;

        public static void Configure(IMapper mapper)
            => Mapper = mapper;

        private static void ValidateConfiguration()
        {
            if (Mapper == null)
            {
                throw new InvalidOperationException(NotConfiguredMessage);
            }
        }

        #endregion
    }
}
