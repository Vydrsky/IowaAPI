using Iowa.Domain.EvaluationAggregate;

using MediatR;

namespace Iowa.Application.Evaluation.Queries.GetAllEvaluations;

public record GetAllEvaluationsQuery : IRequest<IEnumerable<EvaluationAggregate>>;
