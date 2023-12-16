using System.Reflection;

using Iowa.Domain.Account;
using Iowa.Domain.Common.Models;
using Iowa.Domain.Evaluation;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.UserAggregate;
using Iowa.SqlServer.DataAccess.Interceptors;

using Microsoft.EntityFrameworkCore;

namespace Iowa.SqlServer.DataAccess;

public class ApplicationDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public ApplicationDbContext(DbContextOptions options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<GameAggregate> Games { get; set; }
    public DbSet<UserAggregate> Users { get; set; }
    public DbSet<AccountAggregate> Accounts { get; set; }
    public DbSet<EvaluationAggregate> Evaulations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
