using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using System.Collections.Generic;
using EnduranceJudge.Core.Extensions;

namespace EnduranceJudge.Core.Mappings
{
    public abstract class MappingProfile : Profile
    {
        private static readonly Type MapFromType = typeof(IMapFrom<>);
        private static readonly Type MapToType = typeof(IMapTo<>);
        private static readonly Type MapType = typeof(IMap<>);
        private static readonly Type MapExplicitlyType = typeof(IMapExplicitly);

        protected MappingProfile()
            => this.RegisterMaps();

        protected abstract Assembly[] Assemblies { get; }

        protected virtual void RegisterMaps()
            => this.Assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Type = t,
                    MapFromTypes = GetMappingModels(t, MapFromType),
                    MapToTypes = GetMappingModels(t, MapToType),
                    MapTypes = GetMappingModels(t, MapType),
                    ExplicitMapTypes = t
                        .GetInterfaces()
                        .Where(i => MapExplicitlyType.IsAssignableFrom(i))
                        .Select(i => (IMapExplicitly)Activator.CreateInstance(t)!)
                        .FirstOrDefault(),
                })
                .ForEach(obj =>
                {
                    obj.MapFromTypes.ForEach(mapFrom => this.CreateMap(mapFrom, obj.Type));
                    obj.MapToTypes.ForEach(mapTo => this.CreateMap(obj.Type, mapTo));
                    obj.MapTypes.ForEach(map =>
                    {
                        this.CreateMap(obj.Type, map);
                        this.CreateMap(map, obj.Type);
                    });

                    obj.ExplicitMapTypes?.CreateExplicitMap(this);
                });

        protected static IEnumerable<Type> GetMappingModels(Type source, Type mappingType)
            => source
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == mappingType)
                .Select(i => i.GetGenericArguments().First());
    }
}
