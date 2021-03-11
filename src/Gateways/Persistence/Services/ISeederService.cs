using EnduranceContestManager.Core.ConventionalServices;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Services
{
    public interface ISeederService : IService
    {
        Task Seed();
    }
}
