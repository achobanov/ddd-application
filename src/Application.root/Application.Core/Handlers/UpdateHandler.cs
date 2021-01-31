using EnduranceContestManager.Application.Core.Requests;
using EnduranceContestManager.Application.Interfaces.Core;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public class UpdateHandler<TEntity, TRequest> : Handler<TRequest>
        where TEntity : IAggregateRoot
        where TRequest : IIdentifiableRequest, IMapTo<TEntity>
    {
        private readonly ICommandRepository<TEntity> commands;

        protected UpdateHandler(ICommandRepository<TEntity> commands)
        {
            this.commands = commands;
        }

        protected override async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = await this.commands.Find(request.Id);

            if (this.CustomUpdate != default)
            {
                entity = this.CustomUpdate(request);
            }
            else
            {
                var update = request.Map<TEntity>();
                entity = entity.MapFrom(update);
            }

            await this.commands.Save(entity, cancellationToken);
        }

        protected Func<TRequest, TEntity> CustomUpdate { private get; set; }
    }
}
