using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Phases;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class PhaseEntity : EntityModel, IPhaseState, IMapExplicitly
    {
        public int LengthInKilometers { get; set; }

        public bool IsFinal { get; set; }

        [JsonIgnore]
        public IList<PhaseForCategoryEntity> PhasesForCategories { get; set; }

        public int CompetitionId { get; set; }

        [JsonIgnore]
        public CompetitionEntity Competition { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<PhaseEntity, Phase>()
                .EqualityComparison((entity, phase) => entity.Id == phase.Id);

            mapper.CreateMap<Phase, PhaseEntity>()
                .EqualityComparison((phase, entity) => entity.Id == phase.Id);
        }
    }
}
