using Iowa.Application.Common.Exceptions.Base;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Iowa.Domain._Common.Exceptions.Base;

namespace Iowa.API.Middleware;

public class DomainExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<DomainExceptionHandlingMiddleware> _logger;
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public DomainExceptionHandlingMiddleware(ILogger<DomainExceptionHandlingMiddleware> logger, ProblemDetailsFactory problemDetailsFactory)
    {
        _logger = logger;
        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var exception = ex as IDomainException;
            if (exception == null) throw;

            _logger.LogError(exception.Detail);
            await HandleDomainExceptionAsync(context, exception);
        }
    }

    private async Task HandleDomainExceptionAsync(HttpContext context, IDomainException ex)
    {
        ProblemDetails problemDetails = _problemDetailsFactory
            .CreateProblemDetails(
            context,
            statusCode: (int)ex.StatusCode,
            title: "Domain rule violation.",
            detail: ex.Detail);

        var json = JsonSerializer.Serialize(problemDetails);

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();

        await context.Response.WriteAsync(json);
    }
}