using Iowa.Application.Common.Interfaces.Authentication;
using Iowa.Application.Common.Interfaces.Persistence;
using Iowa.Application.Common.Interfaces.Services;
using Iowa.Infrastructure.Authentication;
using Iowa.Infrastructure.Common;
using Iowa.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Iowa.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        return services;
    }
}