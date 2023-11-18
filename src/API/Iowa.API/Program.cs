using Iowa.API.Middleware;
using Iowa.Application;
using Iowa.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//DEPENDENCY INJECTION
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddLogging(options => {
    options.AddConsole();
});

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

//MIDDLEWARE PIPELINE
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
