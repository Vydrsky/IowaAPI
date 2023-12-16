using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.AccountAggregate;

namespace Iowa.SqlServer.DataAccess.Configurations;

public class AccountConfigurations : IEntityTypeConfiguration<AccountAggregate>
{
    public void Configure(EntityTypeBuilder<AccountAggregate> builder)
    {
        ConfigureAccountsTable(builder);
    }

    private void ConfigureAccountsTable(EntityTypeBuilder<AccountAggregate> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => AccountId.Create(value)); ;
        builder.Property(u => u.UserId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));
        builder.Property(u => u.GameId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => GameId.Create(value));
    }
}
