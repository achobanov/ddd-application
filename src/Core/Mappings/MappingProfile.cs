using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using EnduranceContestManager.Core.Extensions;

namespace EnduranceContestManager.Core.Mappings
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
                     && typeof(IMapCreator).IsAssignableFrom(t))
                .ForEach(this.CreateMap);

        private void CreateMap(Type type)
        {
            if (Activator.CreateInstance(type) is IMapCreator instance)
            {
                instance.CreateMap(this);
                
                return;
            }

            throw new ArgumentException(
                $"Type '{type}' does not implement 'IMapCreator'.",
                nameof(type));
        }
    }
}