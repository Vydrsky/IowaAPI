using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Domain.EvaluationAggregate.Events;

using MediatR;

namespace Iowa.Application.User.Events;

public class EvaluationCreatedEventHandler : INotificationHandler<EvaluationCreated>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EvaluationCreatedEventHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(EvaluationCreated notification, CancellationToken cancellationToken)
    {
        (await _userRepository.GetByIdAsync(notification.Evaluation.UserId)).DisableUser();
        await _unitOfWork.PublishNewDomainEvents();
    }
}
