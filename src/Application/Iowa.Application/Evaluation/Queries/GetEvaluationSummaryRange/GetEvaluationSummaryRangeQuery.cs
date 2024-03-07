using Iowa.Application.Evaluation.Results;

using MediatR;

namespace Iowa.Application.Evaluation.Queries.GetEvaluationSummaryRange;

public record GetEvaluationSummaryRangeQuery(Guid Id) : IRequest<IEnumerable<EvaluationSummaryRangeResult>>;
