using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Domain.Evaluation;
using Iowa.Domain.EvaluationAggregate.ValueObjects;

namespace Iowa.Application._Common.Interfaces.Persistence;

public interface IEvaluationRepository : IGenericRepository<EvaluationAggregate, EvaluationId>
{
}
