using MediatR;

namespace application.abstractions.messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}
