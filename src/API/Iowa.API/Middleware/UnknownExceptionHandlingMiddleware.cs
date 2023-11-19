﻿using Iowa.Application.Common.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using System.Text.Json;

namespace Iowa.API.Middleware;

public class UnknownExceptionHandlingMiddleware : IMiddleware {
    private readonly ILogger<UnknownExceptionHandlingMiddleware> _logger;
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public UnknownExceptionHandlingMiddleware(ILogger<UnknownExceptionHandlingMiddleware> logger, ProblemDetailsFactory problemDetailsFactory) {
        _logger = logger;
        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next(context);
        }
        catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            await HandleUknownExceptionAsync(context);
        }
    }

    private async Task HandleUknownExceptionAsync(HttpContext context) {
        ProblemDetails problemDetails = _problemDetailsFactory
            .CreateProblemDetails(
            context,
            statusCode: (int)HttpStatusCode.InternalServerError,
            title: "Internal Server Error",
            detail: "An unknown error has occured. Please try again later.");

        var json = JsonSerializer.Serialize(problemDetails);

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();

        await context.Response.WriteAsync(json);
    }
}
