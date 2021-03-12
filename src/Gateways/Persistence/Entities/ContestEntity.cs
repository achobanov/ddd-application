using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class EventEntity : EntityModel<Event>, IEventState
    {
        public EventEntity()
        {
        }

        [JsonConstructor]
        public EventEntity(
            int id,
            string name,
            string populatedPlace,
            string presidentGroundJury,
            string feiTechDelegate,
            string feiVetDelegate,
            string presidentVetCommission,
            string foreignJudge,
            string activeVet)
            : base(id)
        {
            this.Name = name;
            this.PopulatedPlace = populatedPlace;
            this.PresidentGroundJury = presidentGroundJury;
            this.FeiTechDelegate = feiTechDelegate;
            this.FeiVetDelegate = feiVetDelegate;
            this.PresidentVetCommission = presidentVetCommission;
            this.ForeignJudge = foreignJudge;
            this.ActiveVet = activeVet;
        }

        public string Name { get; private set; }

        public string PopulatedPlace { get; internal set; }

        public string PresidentGroundJury { get; internal set; }

        public string FeiTechDelegate { get; internal set; }

        public string PresidentVetCommission { get; internal set; }

        public string FeiVetDelegate { get; internal set; }

        public string ForeignJudge { get; internal set; }

        public string ActiveVet { get; internal set; }

        [JsonIgnore]
        public IList<CompetitionEntity> Trials { get; internal set; }
    }
}
