using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using System.Collections.Generic;

namespace EnduranceJudge.Core.Mappings
{
    public abstract class MappingProfile : Profile
    {
        private static readonly Type MapFromType = typeof(IMapFrom<>);
        private static readonly Type MapToType = typeof(IMapTo<>);
        private static readonly Type MapExplicitlyType = typeof(IMapExplicitly);

        protected MappingProfile()
            => this.RegisterMaps();

        protected abstract Assembly[] Assemblies { get; }

        private void RegisterMaps()
            => this.Assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Type = t,
                    AllMapFrom = GetMappingModels(t, MapFromType),
                    AllMapTo = GetMappingModels(t, MapToType),
                    ExplicitMap = t
                        .GetInterfaces()
                        .Where(i => MapExplicitlyType.IsAssignableFrom(i))
                        .Select(i => (IMapExplicitly)Activator.CreateInstance(t)!)
                        .FirstOrDefault(),
                })
                .ForEach(obj =>
                {
                    obj.AllMapFrom.ForEach(mapFrom => this.CreateMap(mapFrom, obj.Type));
                    obj.AllMapTo.ForEach(mapTo => this.CreateMap(obj.Type, mapTo));
                    obj.ExplicitMap?.CreateExplicitMap(this);
                });

        protected static IEnumerable<Type> GetMappingModels(Type source, Type mappingType)
            => source
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == mappingType)
                .Select(i => i.GetGenericArguments().First());
    }
}
