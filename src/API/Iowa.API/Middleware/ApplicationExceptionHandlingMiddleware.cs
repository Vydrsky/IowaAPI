using Iowa.Application.Common.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.Json;

namespace Iowa.API.Middleware;

public class ApplicationExceptionHandlingMiddleware : IMiddleware {
    private readonly ILogger<ApplicationExceptionHandlingMiddleware> _logger;
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public ApplicationExceptionHandlingMiddleware(ILogger<ApplicationExceptionHandlingMiddleware> logger, ProblemDetailsFactory problemDetailsFactory) {
        _logger = logger;
        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next(context);
        }
        catch (Exception ex) {
            var exception = ex as IApplicationException;
            if (exception == null) throw;

            _logger.LogError(exception.Detail);
            await HandleApplicationExceptionAsync(context, exception);
        }
    }

    private async Task HandleApplicationExceptionAsync(HttpContext context, IApplicationException ex) {
        ProblemDetails problemDetails = _problemDetailsFactory
            .CreateProblemDetails(
            context,
            statusCode: (int)ex.StatusCode,
            title: ex.Title,
            detail: ex.Detail);

        var json = JsonSerializer.Serialize(problemDetails);

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();

        await context.Response.WriteAsync(json);
    }
}
