using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;

namespace EnduranceJudge.Application.Events.Queries.GetEvent
{
    public class EnduranceEventForUpdateModel : IEnduranceEventState
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PopulatedPlace { get; private set; }
        public string CountryIsoCode { get; private set; }
        public string PresidentGroundJury { get; private set; }
        public string PresidentVetCommission { get; private set; }
        public string ForeignJudge { get; private set; }
        public string FeiTechDelegate { get; private set; }
        public string FeiVetDelegate { get; private set; }
        public string ActiveVet { get; private set; }
        public string MembersOfVetCommittee { get; private set; }
        public string MembersOfJudgeCommittee { get; private set; }
        public string Stewards { get; private set; }
    }
}
