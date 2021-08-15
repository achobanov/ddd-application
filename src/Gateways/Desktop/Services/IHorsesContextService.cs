using EnduranceJudge.Application.Events.Queries.GetHorses;
using EnduranceJudge.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Services
{
    public interface IHorsesContextService : IContextService
    {
        Task<IEnumerable<HorseModel>> GetAll();
    }
}
