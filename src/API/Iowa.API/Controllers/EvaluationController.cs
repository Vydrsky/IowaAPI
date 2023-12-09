using Iowa.API.Controllers.Base;
using Iowa.Contracts.Evaluation.Responses;

using Microsoft.AspNetCore.Mvc;

namespace Iowa.API.Controllers;

public class EvaluationController : IowaController
{
    /// <summary>
    /// Returns a list of all evaluations
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<EvaluationResponse>>> GetAllEvaluations() {
        return await Task.Run(Ok);
    }
}
