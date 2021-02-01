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
                     && (typeof(IMapExplicitly).IsAssignableFrom(t)
                         || typeof(IMapTo).IsAssignableFrom(t)
                         || typeof(IMapFrom).IsAssignableFrom(t)))
                .ForEach(this.CreateMap);

        private void CreateMap(Type type)
        {
            var instance = Activator.CreateInstance(type);
            if (instance is IMapFrom mapFrom)
            {
                mapFrom.CreateFromMap(this);
            }
            else if (instance is IMapTo mapTo)
            {
                mapTo.CreateToMap(this);
            }
            else if (instance is IMapExplicitly mapExplicitly)
            {
                mapExplicitly.CreateExplicitMap(this);
            }

            throw new ArgumentException(
                $"Type '{type}' does not implement 'IMapCreator'.",
                nameof(type));
        }
    }
}
