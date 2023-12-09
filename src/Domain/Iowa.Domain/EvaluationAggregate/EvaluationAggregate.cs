using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.EvaluationAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.Domain.Evaluation;

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
        EvaluationDate = EvaluationDate;
    }

    public static EvaluationAggregate Create(UserId userId, AccountId accountId, bool isPassed, DateTime evaluationDate)
    {
        return new(
            EvaluationId.CreateUnique(),
            userId,
            accountId,
            isPassed,
            evaluationDate);
    }
}