using application.abstractions.messaging;

namespace application.breads.commands.CreateBread
{
    internal sealed class CreateBreadHandler : ICommandHandler<CreateBreadCommand, Guid>
    {
        private readonly domain.abstractions.IBreadRepository breadRepository;

        public CreateBreadHandler(domain.abstractions.IBreadRepository breadRepository)
        {
            this.breadRepository = breadRepository;
        }

        public Task<Guid> Handle(CreateBreadCommand request, CancellationToken cancellationToken)
        {
            var bread = domain.models.NewStarter

            breadRepository.Insert(bread);
             
            return Task.FromResult(Guid.NewGuid());
        }
    }
}