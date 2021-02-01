using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public abstract class CreateHandler<TEntity, TDataEntry, TRequest> : Handler<TRequest, int>
        where TEntity : IAggregateRoot
        where TDataEntry : DataEntry
        where TRequest : IRequest<int>, IEntityState
    {
        private readonly IFactory<TEntity> factory;
        private readonly ICommandRepository<TDataEntry> commands;

        protected CreateHandler(IFactory<TEntity> factory, ICommandRepository<TDataEntry> commands)
        {
            this.factory = factory;
            this.commands = commands;
        }

        public override async Task<int> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = this.factory.Create(request);

            var dataEntry = entity.Map<TDataEntry>();

            await this.commands.Save(dataEntry, cancellationToken);

            return entity.Id;
        }
    }
}
