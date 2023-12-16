using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Domain.EvaluationAggregate;
using Iowa.Domain.EvaluationAggregate.ValueObjects;
using Iowa.SqlServer.DataAccess.Repositories.Base;

namespace Iowa.SqlServer.DataAccess.Repositories;

public class EvaluationRepository : GenericSqlServerRepository<EvaluationAggregate, EvaluationId>, IEvaluationRepository
{
    public EvaluationRepository(ApplicationDbContext context) : base(context.Evaluations)
    {
    }
}
