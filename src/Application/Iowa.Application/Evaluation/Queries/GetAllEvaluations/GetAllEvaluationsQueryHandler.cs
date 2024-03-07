using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Domain.EvaluationAggregate;

using MediatR;

namespace Iowa.Application.Evaluation.Queries.GetAllEvaluations;

public class GetAllEvaluationsQueryHandler : IRequestHandler<GetAllEvaluationsQuery, IEnumerable<EvaluationAggregate>>
{
    private readonly IEvaluationRepository _evaluationRepository;

    public GetAllEvaluationsQueryHandler(IEvaluationRepository evaluationRepository)
    {
        _evaluationRepository = evaluationRepository;
    }

    public async Task<IEnumerable<EvaluationAggregate>> Handle(GetAllEvaluationsQuery request, CancellationToken cancellationToken)
    {
        return await _evaluationRepository.GetAllAsync();
    }
}
