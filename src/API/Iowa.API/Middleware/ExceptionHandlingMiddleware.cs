﻿using Iowa.Application.Common.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using System.Text.Json;

namespace Iowa.API.Middleware;

public class ExceptionHandlingMiddleware : IMiddleware {
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, ProblemDetailsFactory problemDetailsFactory) {
        _logger = logger;
        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next(context);
        }
        catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex) {
        ProblemDetails problemDetails;
        if (ex is IApplicationException) {
            problemDetails = _problemDetailsFactory
                .CreateProblemDetails(
                context,
                statusCode: (int)((IApplicationException)ex).StatusCode,
                title: ((IApplicationException)ex).Title,
                detail: ((IApplicationException)ex).Detail);
        }
        else {
            problemDetails = _problemDetailsFactory
                .CreateProblemDetails(
                context,
                statusCode: (int)HttpStatusCode.InternalServerError,
                title: "Internal Server Error",
                detail: "An unexpected error has occured.");
        }

        var json = JsonSerializer.Serialize(problemDetails);

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();

        await context.Response.WriteAsync(json);
    }
}