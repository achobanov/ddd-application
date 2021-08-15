using EnduranceJudge.Application.Events.Queries.GetAthletes;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Services.Implementations
{
    public class AthletesContextService : IAthletesContextService
    {
        private readonly IApplicationService application;
        private IEnumerable<AthleteModel> athletes;

        public AthletesContextService(IApplicationService application)
        {
            this.application = application;
        }

        public async Task<IEnumerable<AthleteModel>> GetAll()
        {
            if (this.athletes == null)
            {
                await this.Load();
            }

            return this.athletes;
        }

        public async Task Load()
        {
            var query = new GetAthletes();
            this.athletes = await this.application.Execute(query);
        }
    }
}
