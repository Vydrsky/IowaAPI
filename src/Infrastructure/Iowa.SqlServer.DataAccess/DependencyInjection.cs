﻿using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Application._Common.Interfaces.Persistence.Base;
using Iowa.Application._Common.Interfaces.Persistence.Seeding;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Infrastructure.Persistence;
using Iowa.SqlServer.DataAccess.Interceptors;
using Iowa.SqlServer.DataAccess.Repositories;
using Iowa.SqlServer.DataAccess.Seeding;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Iowa.SqlServer.DataAccess;

public static class DependencyInjection
{

    public static IServiceCollection AddSqlServerPersistance(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Default"));
            options.AddInterceptors();
        });
        AddRepositories(services);
        AddInterceptors(services);
        AddDatabaseSeeder(services);

        return services;
    }

    private static IServiceCollection AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IEvaluationRepository, EvaluationRepository>();

        return services;
    }

    private static IServiceCollection AddInterceptors(IServiceCollection services)
    {
        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<DomainEventPublisher>();

        return services;
    }

    private static IServiceCollection AddDatabaseSeeder(IServiceCollection services)
    {
        services.AddScoped<ISeeder, TruncateDbSeeder>();

        return services;
    }
}
