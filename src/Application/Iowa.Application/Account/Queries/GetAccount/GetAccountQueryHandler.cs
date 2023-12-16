using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Domain.AccountAggregate;
using Iowa.Domain.AccountAggregate.ValueObjects;

using MediatR;

namespace Iowa.Application.Account.Queries.GetAccount;

public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountAggregate>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountAggregate> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        return await _accountRepository.GetByIdAsync(AccountId.Create(request.Id));
    }
}
