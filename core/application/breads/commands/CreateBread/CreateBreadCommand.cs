using application.abstractions.messaging;

namespace application.breads.commands.CreateBread
{
    public sealed record CreateBreadCommand(Guid BreadId, string Name) : ICommand<Guid>;
}
