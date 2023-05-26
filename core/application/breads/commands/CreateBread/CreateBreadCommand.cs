using application.abstractions.messaging;
using MediatR;

namespace application.breads.commands.CreateBread
{
    public sealed record CreateBreadCommand(Guid BreadId, string Name) : ICommand<Guid>;
}
