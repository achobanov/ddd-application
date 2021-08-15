using EnduranceJudge.Application.Events.Queries.GetAthletes;
using EnduranceJudge.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Services
{
    public interface IAthletesContextService : IContextService
    {
        Task<IEnumerable<AthleteModel>> GetAll();
    }
}
