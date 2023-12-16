using Iowa.Application._Common.Interfaces.Persistence.Seeding;

using Microsoft.EntityFrameworkCore;

namespace Iowa.SqlServer.DataAccess.Seeding;

public class TruncateDbSeeder : ISeeder
{
    private readonly ApplicationDbContext _context;

    public TruncateDbSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public void SeedDb()
    {
        var tableNames = _context.Model.GetEntityTypes()
            .Select(t => t.GetTableName())
            .Distinct()
            .ToList();

        foreach (var tableName in tableNames)
        {
            _context.Database.ExecuteSqlRaw($"DELETE FROM {tableName};");
        }
    }
}
