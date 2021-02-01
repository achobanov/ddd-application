using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Application.Core.Requests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public class UpdateHandler<TEntity, TDataEntry, TRequest> : Handler<TRequest>
        where TEntity : IAggregateRoot
        where TDataEntry : DataEntry
        where TRequest : IIdentifiableRequest, IMapTo<TEntity>
    {
        private readonly ICommandRepository<TDataEntry> commands;

        protected UpdateHandler(ICommandRepository<TDataEntry> commands)
        {
            this.commands = commands;
        }

        protected override async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = await this.commands.Find<TEntity>(request.Id);

            this.Update(entity, request);

            var dataEntry = entity.Map<TDataEntry>();

            await this.commands.Save(dataEntry, cancellationToken);
        }

        protected virtual void Update(TEntity existing, TRequest request)
        {
            var update = request.Map<TEntity>();
            existing.MapFrom(update);
        }
    }
}
