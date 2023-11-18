﻿using Microsoft.Extensions.DependencyInjection;

namespace Iowa.Application; 

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        return services;
    }
}