using Iowa.Application._Common.Interfaces.Persistence.Seeding;

namespace Iowa.API.Extensions;

public static class ApiExtensions
{
    public static WebApplication AddDbSeeding(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
                seeder.SeedDb();
            }
        }

        return app;
    }
}
