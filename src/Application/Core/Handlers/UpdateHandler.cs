using EnduranceContestManager.Application.Core.Requests;
using EnduranceContestManager.Application.Interfaces.Core;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public class UpdateHandler<TRequest, TEntity> : Handler<TRequest>
        where TRequest : IIdentifiableRequest, IMapTo<TEntity>
        where TEntity : IAggregateRoot
    {
        private readonly ICommandRepository<TEntity> commands;

        protected UpdateHandler(ICommandRepository<TEntity> commands)
        {
            this.commands = commands;
        }

        protected override async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = await this.commands.Find<TEntity>(request.Id);

            this.Update(entity, request);

            await this.commands.Save(entity, cancellationToken);
        }

        protected virtual void Update(TEntity entity, TRequest request)
        {
            var update = request.Map<TEntity>();
            entity.MapFrom(update);
        }
    }
}
