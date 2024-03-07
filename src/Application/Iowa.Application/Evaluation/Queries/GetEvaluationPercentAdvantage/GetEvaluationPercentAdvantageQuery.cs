using MediatR;

namespace Iowa.Application.Evaluation.Queries.GetEvaluationPercentAdvantage;

public record GetEvaluationPercentAdvantageQuery(Guid Id) : IRequest<short>;
