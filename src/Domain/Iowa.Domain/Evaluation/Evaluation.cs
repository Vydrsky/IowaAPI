using Iowa.Domain.Account.ValueObjects;
using Iowa.Domain.Common.Models;
using Iowa.Domain.Evaluation.ValueObjects;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Domain.Evaluation;

public sealed class Evaluation : AggregateRoot<EvaluationId> {
    public bool IsPassed { get; private set; }
    public DateTime PassedAt { get; private set; }
    public UserId UserId { get; private set; }
    public AccountId AccountId { get; private set; }

    private Evaluation(EvaluationId id, UserId userId, AccountId accountId, bool isPassed, DateTime passedAt) : base(id) {
        UserId = userId;
        AccountId = accountId;
        IsPassed = isPassed;
        PassedAt = passedAt;
    }

    public static Evaluation Create(UserId userId, AccountId accountId, bool isPassed, DateTime passedAt) {
        return new(
            EvaluationId.CreateUnique(),
            userId,
            accountId,
            isPassed,
            passedAt);
    }
}