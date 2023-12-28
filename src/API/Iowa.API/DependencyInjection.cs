using System.Reflection;

using Iowa.API.Middleware;

using Mapster;

using MapsterMapper;

using Microsoft.AspNetCore.Mvc.Formatters;

namespace Iowa.API;

public static class DependencyInjection {
    public static IServiceCollection AddPresentation(this IServiceCollection services) {
        AddMapping(services);
        AddMiddlewares(services);
        AddLogging(services);

        services.AddCors(o => o.AddPolicy("DefaultCORSPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

        services.AddControllers(options => {
            options.OutputFormatters.RemoveType<StringOutputFormatter>();
            });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    private static IServiceCollection AddMapping(this IServiceCollection services) {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }

    private static IServiceCollection AddMiddlewares(this IServiceCollection services) {
        services.AddScoped<UnknownExceptionHandlingMiddleware>();
        services.AddScoped<ApplicationExceptionHandlingMiddleware>();
        services.AddScoped<ValidationExceptionHandlingMiddleware>();
        services.AddScoped<DomainExceptionHandlingMiddleware>();
        return services;
    }

    private static IServiceCollection AddLogging(this IServiceCollection services) {
        services.AddLogging(options => {
            options.AddConsole();
        });
        return services;
    }
}
