using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Phases;
using EnduranceJudge.Domain.Aggregates.Event.PhasesForCategory;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class PhaseForCategoryEntity : EntityModel, IPhaseForCategoryState, IMapExplicitly
    {
        public int MaxRecoveryTimeInMinutes { get; set;}

        public int RestTimeInMinutes { get; set;}

        public Category Category { get; set; }

        public int PhaseId { get; set; }

        [JsonIgnore]
        public PhaseEntity Phase { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<PhaseForCategoryEntity, PhaseForCategory>()
                .EqualityComparison((e, pfc) => e.Id == pfc.Id);

            mapper.CreateMap<PhaseForCategory, PhaseForCategoryEntity>()
                .EqualityComparison((e, pfc) => e.Id == pfc.Id);
        }
    }
}
