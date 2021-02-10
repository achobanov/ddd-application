namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public abstract class EntityStore
    {
        protected EntityStore()
        {
        }

        protected EntityStore(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
