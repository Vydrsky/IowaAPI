namespace Iowa.Application.Evaluation.Results;

public record EvaluationSummaryRangeResult(
    string Name,
    long AccountBalance,
    bool CurrentUser);