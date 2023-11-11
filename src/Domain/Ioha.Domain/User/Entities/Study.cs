using Iowa.Domain.Common.Models;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Domain.User.Entities;

public sealed class Study : Entity<StudyId> {
    public bool IsPassed { get; }
    public DateTime PassedAt { get; }

    private Study(StudyId id, bool isPassed, DateTime passedAt): base(id) {
        IsPassed = isPassed;
        PassedAt = passedAt;
    }

    public static Study Create(bool isPassed, DateTime passedAt) {
        return new(
            StudyId.CreateUnique(),
            isPassed,
            passedAt);
    }
}