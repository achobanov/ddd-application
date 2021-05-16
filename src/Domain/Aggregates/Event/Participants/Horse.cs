using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public class Horse : DomainBase<EventHorseException>
    {
        private Horse()
        {
        }

        public Horse(int id) : base(id)
        {
        }
    }
}
