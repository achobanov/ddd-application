using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Core.Handlers
{
    public class UpdateHandler<TRequest, TEntity> : Handler<TRequest>
        where TRequest : IIdentifiableRequest, IMapTo<TEntity>
        where TEntity : IAggregateRoot
    {
        private readonly ICommandsBase<TEntity> commandses;

        protected UpdateHandler(ICommandsBase<TEntity> commandses)
        {
            this.commandses = commandses;
        }

        protected override async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = await this.commandses.Find<TEntity>(request.Id);

            this.Update(entity, request);

            await this.commandses.Save(entity, cancellationToken);
        }

        protected virtual void Update(TEntity entity, TRequest request)
        {
            var update = request.Map<TEntity>();
            entity.MapFrom(update);
        }
    }
}
