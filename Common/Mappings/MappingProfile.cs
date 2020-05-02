using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Blog.Common.Extensions;

namespace Blog.Common.Mappings
{
    public abstract class MappingProfile : Profile
    {
        public MappingProfile()
            => this.RegisterMaps();

        protected abstract Assembly[] Assemblies { get; }

        private void RegisterMaps()
            => this.Assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t =>
                    !t.IsAbstract
                     && !t.IsInterface
                     && (typeof(IMapCreator).IsAssignableFrom(t)
                        || typeof(IMapExplicitly).IsAssignableFrom(t)))
                .ForEach(this.CreateMap);

        private void CreateMap(Type type)
        {
            var instance = Activator.CreateInstance(type);
            if (instance is IMapCreator mapCreator)
            {
                mapCreator.CreateMap(this);

                return;
            }

            if (instance is IMapExplicitly explicitMapCreator)
            {
                explicitMapCreator.CreateMap(this);

                return;
            }

            throw new ArgumentException(
                $"Cannot register map. Type '{type}' must implement 'IMapCreator' or 'IMapExplicitly",
                nameof(type));
        }
    }
}