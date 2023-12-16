using Iowa.Domain.AccountAggregate;

using MediatR;

namespace Iowa.Application.Account.Queries.GetAccount;

public record GetAccountQuery(Guid Id) : IRequest<AccountAggregate>;
