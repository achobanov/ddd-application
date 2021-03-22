using System.ComponentModel.DataAnnotations;

namespace EnduranceJudge.Gateways.Persistence.Core
{
    public abstract class EntityModel
    {
        [Key]
        public int Id { get; set; }
    }
}
