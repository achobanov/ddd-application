using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public abstract class CreateHandler<TRequest, TEntity> : Handler<TRequest, int>
        where TRequest : IRequest<int>, IEntityState
        where TEntity : IAggregateRoot
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
