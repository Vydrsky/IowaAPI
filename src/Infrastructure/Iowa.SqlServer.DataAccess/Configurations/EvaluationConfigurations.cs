using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Iowa.Domain.Evaluation;
using Iowa.Domain.EvaluationAggregate.ValueObjects;
using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;

namespace Iowa.SqlServer.DataAccess.Configurations;

public class EvaluationConfigurations : IEntityTypeConfiguration<EvaluationAggregate>
{
    public void Configure(EntityTypeBuilder<EvaluationAggregate> builder)
    {
        ConfigureEvaluationsTable(builder);
    }

    private void ConfigureEvaluationsTable(EntityTypeBuilder<EvaluationAggregate> builder)
    {
        builder.ToTable("Evaluations");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => EvaluationId.Create(value)); ;
        builder.Property(u => u.AccountId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => AccountId.Create(value));
        builder.Property(u => u.UserId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));
    }
}
