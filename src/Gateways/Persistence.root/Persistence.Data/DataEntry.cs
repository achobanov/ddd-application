namespace EnduranceContestManager.Gateways.Persistence.Data
{
    public abstract class DataEntry
    {
        protected DataEntry()
        {
        }

        protected DataEntry(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
