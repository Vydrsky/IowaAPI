using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.EvaluationAggregate.Events;
using Iowa.Domain.EvaluationAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Domain.EvaluationAggregate;

public sealed class EvaluationAggregate : AggregateRoot<EvaluationId>
{
    public bool IsPassed { get; private set; }
    public DateTime EvaluationDate { get; private set; }
    public UserId UserId { get; private set; }
    public AccountId AccountId { get; private set; }

    private EvaluationAggregate(EvaluationId id, UserId userId, AccountId accountId, bool isPassed, DateTime evaluationDate) : base(id)
    {
        UserId = userId;
        AccountId = accountId;
        IsPassed = isPassed;
        EvaluationDate = evaluationDate;
    }

    public static EvaluationAggregate Create(UserId userId, AccountId accountId, bool isPassed, DateTime evaluationDate, EvaluationId? id = null)
    {
        var evaluation = new EvaluationAggregate(
            id ?? EvaluationId.CreateUnique(),
            userId,
            accountId,
            isPassed,
            evaluationDate);

        evaluation.AddDomainEvent(new EvaluationCreated(evaluation));

        return evaluation;
    }

#pragma warning disable CS8618
    private EvaluationAggregate()
    {

    }
#pragma warning restore CS8618
}