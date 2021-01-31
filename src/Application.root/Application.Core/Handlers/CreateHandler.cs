using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Application.Interfaces.Core;
using EnduranceContestManager.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public abstract class CreateHandler<TEntity, TRequest> : Handler<TRequest, int>
        where TEntity : IAggregateRoot
        where TRequest : IRequest<int>, IEntityState
    {
        private readonly IFactory<TEntity> factory;
        private readonly ICommandRepository<TEntity> commands;

        protected CreateHandler(IFactory<TEntity> factory, ICommandRepository<TEntity> commands)
        {
            this.factory = factory;
            this.commands = commands;
        }

        public override async Task<int> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = this.factory.Create(request);

            await this.commands.Save(entity, cancellationToken);

            return entity.Id;
        }
    }
}
