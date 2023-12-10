using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Domain.Evaluation;
using Iowa.Domain.EvaluationAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess.Repositories.Base;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class EvaluationRepository : GenericRepository<EvaluationAggregate, EvaluationId>, IEvaluationRepository
{
}
