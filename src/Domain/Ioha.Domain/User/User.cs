using Iowa.Domain.Common.Models;
using Iowa.Domain.User.Entities;
using Iowa.Domain.User.ValueObjects;

namespace Iowa.Domain.User;

public sealed class User : AggregateRoot<UserId> {
    public string UserCode { get; private set; }

    public Study Study { get; private set; }

    private User(UserId id, string userCode, Study study) : base(id) {
        UserCode = userCode;
        Study = study;
    }

    public static User Create(string userCode, Study study) {
        return new(
            UserId.CreateUnique(),
            userCode,
            study);
    }
}