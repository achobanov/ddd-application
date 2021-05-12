namespace EnduranceJudge.Application.Events.Queries.GetEvent
{
    public class EnduranceEventForUpdateModel
    {
        public string Name { get; set; }
        public string PopulatedPlace { get; set; }
        public string CountryIsoCode { get; set; }
        public string PresidentGroundJury { get; set; }
        public string PresidentVetCommission { get; set; }
        public string ForeignJudge { get; set; }
        public string FeiTechDelegate { get; set; }
        public string FeiVetDelegate { get; set; }
        public string ActiveVet { get; set; }
        public string MembersOfVetCommittee { get; set; }
        public string MembersOfJudgeCommittee { get; set; }
        public string Stewards { get; set; }
    }
}
