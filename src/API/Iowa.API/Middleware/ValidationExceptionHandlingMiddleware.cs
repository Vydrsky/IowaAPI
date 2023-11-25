using Iowa.Application.Common.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Iowa.API.Middleware;

public class ValidationExceptionHandlingMiddleware : IMiddleware {
    private readonly ILogger<ValidationExceptionHandlingMiddleware> _logger;

    public ValidationExceptionHandlingMiddleware(ILogger<ValidationExceptionHandlingMiddleware> logger) {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next(context);
        }
        catch (Exception ex) {
            var exception = ex as ValidationException;
            if (exception == null) throw;
            _logger.LogError(ex, ex.Message);
            await HandleValidationExceptionAsync(context, exception);
        }
    }

    private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex) {

        var problemDetails = new ValidationProblemDetails(ex.Errors);
        problemDetails.Status = (int)HttpStatusCode.BadRequest;
        problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        problemDetails.Title = ex.Message;
        problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? context.TraceIdentifier);

        var json = JsonSerializer.Serialize(problemDetails);

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();

        await context.Response.WriteAsync(json);
    }
}
