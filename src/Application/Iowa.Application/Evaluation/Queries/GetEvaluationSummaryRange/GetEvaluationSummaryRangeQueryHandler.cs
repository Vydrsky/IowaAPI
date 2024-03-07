using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Application.Common.Exceptions;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Application.Evaluation.Results;
using Iowa.Domain.EvaluationAggregate.ValueObjects;

using MediatR;

namespace Iowa.Application.Evaluation.Queries.GetEvaluationSummaryRange;

public class GetEvaluationSummaryRangeQueryHandler : IRequestHandler<GetEvaluationSummaryRangeQuery, IEnumerable<EvaluationSummaryRangeResult>>
{
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;

    public GetEvaluationSummaryRangeQueryHandler(IEvaluationRepository evaluationRepository, IAccountRepository accountRepository, IUserRepository userRepository)
    {
        _evaluationRepository = evaluationRepository;
        _accountRepository = accountRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<EvaluationSummaryRangeResult>> Handle(GetEvaluationSummaryRangeQuery request, CancellationToken cancellationToken)
    {
        const int RANGE = 2;

        var evaluations = await _evaluationRepository.GetAllAsync();
        var accounts = await _accountRepository.GetAllAsync();
        var users = await _userRepository.GetAllAsync();
        var userEvaluation = evaluations.First(e => e.Id == EvaluationId.Create(request.Id)) ?? throw new EntityNotFoundException();
        var userAccount = accounts.First(a => a.Id == userEvaluation.AccountId) ?? throw new EntityNotFoundException();
        var user = users.FirstOrDefault(u => u.Id == userEvaluation.UserId) ?? throw new EntityNotFoundException();

        var evalAccounts = evaluations.Where(e => e.Id != userEvaluation.Id).Select(e => accounts.First(a => a.Id == e.AccountId) ?? throw new EntityNotFoundException());

        var higherEvalAccounts = evalAccounts.Where(a => a.Balance > userAccount.Balance).OrderBy(a => a.Balance).Take(RANGE);
        var lowerToTake = (RANGE*2) - higherEvalAccounts.Count();
        var lowerEvalAccounts = evalAccounts.Where(a => a.Balance <= userAccount.Balance).OrderByDescending(a => a.Balance).Take(lowerToTake);

        var higherEvalResults = higherEvalAccounts
            .Select(a => 
            new EvaluationSummaryRangeResult(
                users.FirstOrDefault(u => u.Id == a.UserId)?.UserCode ?? throw new EntityNotFoundException(),
                a.Balance,
                false));

        var lowerEvalResults = lowerEvalAccounts
            .Select(a => 
            new EvaluationSummaryRangeResult(
                users.FirstOrDefault(u => u.Id == a.UserId)?.UserCode ?? throw new EntityNotFoundException(),
                a.Balance,
                false));

        var userResult = new EvaluationSummaryRangeResult(user.UserCode, userAccount.Balance, true);

        return higherEvalResults.ToList().Append(userResult).Concat(lowerEvalResults);
    }
}
