using Iowa.Application._Common.Interfaces.Persistence;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Infrastructure.Persistence;
using Iowa.SqlServer.DataAccess.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Iowa.SqlServer.DataAccess;

public static class DependencyInjection
{

    public static IServiceCollection AddSqlServerPersistance(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer();
        });
        AddRepositories(services);

        return services;
    }

    private static IServiceCollection AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IEvaluationRepository, EvaluationRepository>();

        return services;
    }
}
