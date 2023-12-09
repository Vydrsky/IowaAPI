namespace Iowa.Contracts.Evaluation.Responses;

public record EvaluationResponse(
    Guid Id,
    bool IsPassed,
    DateTime EvaluationDate,
    Guid UserId,
    Guid AccountId);