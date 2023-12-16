using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate;
using Iowa.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iowa.SqlServer.DataAccess.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<UserAggregate>
{
    public void Configure(EntityTypeBuilder<UserAggregate> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<UserAggregate> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));
        builder.Property(u => u.AccountId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => AccountId.Create(value));
        builder.Property(u => u.GameId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => GameId.Create(value));

        builder.Property(u => u.UserCode)
            .HasMaxLength(512);
    }
}
