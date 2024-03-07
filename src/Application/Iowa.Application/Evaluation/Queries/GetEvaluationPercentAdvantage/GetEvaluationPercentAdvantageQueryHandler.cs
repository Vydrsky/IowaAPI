using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Application.Common.Exceptions;
using Iowa.Domain.EvaluationAggregate.ValueObjects;

using MediatR;

namespace Iowa.Application.Evaluation.Queries.GetEvaluationPercentAdvantage;

public class GetEvaluationPercentAdvantageQueryHandler : IRequestHandler<GetEvaluationPercentAdvantageQuery, short>
{
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly IAccountRepository _accountRepository;

    public GetEvaluationPercentAdvantageQueryHandler(IEvaluationRepository evaluationRepository, IAccountRepository accountRepository)
    {
        _evaluationRepository = evaluationRepository;
        _accountRepository = accountRepository;
    }

    public async Task<short> Handle(GetEvaluationPercentAdvantageQuery request, CancellationToken cancellationToken)
    {
        var evaluations = await _evaluationRepository.GetAllAsync();
        var accounts = await _accountRepository.GetAllAsync();
        var userEvaluation = evaluations.First(e => e.Id == EvaluationId.Create(request.Id)) ?? throw new EntityNotFoundException();
        var userAccount = accounts.First(a => a.Id == userEvaluation.AccountId) ?? throw new EntityNotFoundException();

        var evalAccounts = evaluations.Where(e => e.Id != userEvaluation.Id).Select(e => accounts.First(a => a.Id == e.AccountId) ?? throw new EntityNotFoundException());
        var lowerEvalAccounts = evalAccounts.Where(a => a.Balance <= userAccount.Balance && a.Id != userAccount.Id);
        return (short)((double)(lowerEvalAccounts.Count()) / evalAccounts.Count() * 100f);
    }
}
