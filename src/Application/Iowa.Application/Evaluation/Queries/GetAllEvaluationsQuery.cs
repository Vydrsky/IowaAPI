
using Iowa.Domain.EvaluationAggregate;

using MediatR;

namespace Iowa.Application.Evaluation.Queries;

public record GetAllEvaluationsQuery : IRequest<IEnumerable<EvaluationAggregate>>;
