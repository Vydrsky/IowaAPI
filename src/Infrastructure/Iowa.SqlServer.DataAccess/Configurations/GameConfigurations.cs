using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Enums;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Iowa.SqlServer.DataAccess.Configurations;

public class GameConfigurations : IEntityTypeConfiguration<GameAggregate>
{
    public void Configure(EntityTypeBuilder<GameAggregate> builder)
    {
        ConfigureGamesTable(builder);
        ConfigureRoundsTable(builder);
        ConfigureCardsTable(builder);
    }

    private void ConfigureGamesTable(EntityTypeBuilder<GameAggregate> builder)
    {
        builder.ToTable("Games");
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value, 
                value => GameId.Create(value));
        builder.Property(g => g.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
        builder.Property(g => g.AccountId)
            .HasConversion(
                id => id.Value,
                value => AccountId.Create(value));
    }

    private void ConfigureRoundsTable(EntityTypeBuilder<GameAggregate> builder)
    {
        builder.OwnsMany(g => g.Rounds, rb =>
        {
            rb.ToTable("Rounds");
            rb.WithOwner().HasForeignKey("GameId");
            rb.HasKey("Id", "GameId");
            rb.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => RoundId.Create(value));
            
        });

        builder.Metadata
            .FindNavigation(nameof(GameAggregate.Rounds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureCardsTable(EntityTypeBuilder<GameAggregate> builder)
    {
        builder.OwnsMany(c => c.Cards, cb =>
        {
            cb.ToTable("Cards");
            cb.WithOwner().HasForeignKey("GameId");
            cb.HasKey("Id");
            cb.Property(c => c.Type)
                .HasConversion(new EnumToStringConverter<CardType>())
                .HasMaxLength(256);
        });

        builder.Metadata
            .FindNavigation(nameof(GameAggregate.Cards))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
