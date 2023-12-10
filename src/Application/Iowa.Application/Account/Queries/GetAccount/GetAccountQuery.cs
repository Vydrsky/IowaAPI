using Iowa.Domain.Account;

using MediatR;

namespace Iowa.Application.Account.Queries.GetAccount;

public record GetAccountQuery(Guid Id) : IRequest<AccountAggregate>;
