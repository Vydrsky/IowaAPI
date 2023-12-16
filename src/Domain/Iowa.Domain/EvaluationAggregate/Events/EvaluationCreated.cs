using Iowa.Domain.Common.Models;

namespace Iowa.Domain.EvaluationAggregate.Events;

public record EvaluationCreated(EvaluationAggregate Evaluation) : IDomainEvent;
