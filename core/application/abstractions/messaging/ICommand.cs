using MediatR;

namespace application.abstractions.messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
