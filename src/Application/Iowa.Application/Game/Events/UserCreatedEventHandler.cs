using Iowa.Domain.UserAggregate.Events;

using MediatR;

namespace Iowa.Application.Game.Events;

public class UserCreatedEventHandler : INotificationHandler<UserCreated>
{
    public Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
