using Iowa.Domain.UserAggregate;

using MediatR;

namespace Iowa.Application.User.Queries.GetUser;

public record GetUserQuery(Guid Id) : IRequest<UserAggregate>;
