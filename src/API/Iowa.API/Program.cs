using Iowa.API;
using Iowa.API.Middleware;
using Iowa.Application;
using Iowa.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//DEPENDENCY INJECTION
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

var app = builder.Build();

//MIDDLEWARE PIPELINE
app.UseMiddleware<UnknownExceptionHandlingMiddleware>();
app.UseMiddleware<ApplicationExceptionHandlingMiddleware>();
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
