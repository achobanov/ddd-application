using EnduranceJudge.Application.Events.Queries.GetHorses;
using EnduranceJudge.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Services.Implementations
{
    public class HorsesContextService : IHorsesContextService
    {
        private readonly IApplicationService application;
        private IEnumerable<HorseModel> horses;

        public HorsesContextService(IApplicationService application)
        {
            this.application = application;
        }

        public async Task<IEnumerable<HorseModel>> GetAll()
        {
            if (this.horses == null)
            {
                await this.Load();
            }

            return this.horses;
        }

        public async Task Load()
        {
            var query = new GetHorses();
            this.horses = await this.application.Execute(query);
        }
    }
}
