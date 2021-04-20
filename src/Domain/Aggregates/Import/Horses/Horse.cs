using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Import.Horses
{
    public class Horse : DomainModel<HorseException>, IHorseState
    {
        private Horse() : base(default)
        {
        }

        public Horse(
            string feiId,
            string name,
            bool isStallion,
            string breed,
            string trainerFeiId,
            string trainerFirstName,
            string trainerLastName)
            : base(default)
            => this.Validate(() =>
            {
                this.FeiId = feiId.IsRequired(nameof(feiId));
                this.Name = name.IsRequired(nameof(name));
                this.Breed = breed.IsRequired(nameof(breed));
                this.TrainerFeiId = trainerFeiId.IsRequired(nameof(trainerFeiId));
                this.TrainerFirstName = trainerFirstName.IsRequired(nameof(trainerFirstName));
                this.TrainerLastName = trainerLastName.IsRequired(nameof(trainerLastName));
                this.IsStallion = isStallion;
            });

        public string FeiId { get; private set; }
        public string Name { get; private set; }
        public bool IsStallion { get; private set; }
        public string Breed { get; private set; }
        public string TrainerFeiId { get; private set; }
        public string TrainerFirstName { get; private set; }
        public string TrainerLastName { get; private set; }
    }
}
