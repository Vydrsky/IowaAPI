using System.Reflection;

using Iowa.Domain.Account;
using Iowa.Domain.Evaluation;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.UserAggregate;

using Microsoft.EntityFrameworkCore;

namespace Iowa.SqlServer.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<GameAggregate> Games { get; set; }
    public DbSet<UserAggregate> Users { get; set; }
    public DbSet<AccountAggregate> Accounts { get; set; }
    public DbSet<EvaluationAggregate> Evaulations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
