using MediatR;

namespace rpsls.Application.Messaging;

// public interface ICommandBase
// {
// }

public interface ICommand<out TResponse> : IRequest<TResponse>//, ICommandBase
{
}

// public interface ICommand : IRequest//, ICommandBase
// {
// }