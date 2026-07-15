using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressTrackingService.Entities;

namespace ProgressTrackingService.Persistence.EntitiesConfigurations;

public class WeightHistoryConfiguration : IEntityTypeConfiguration<WeightHistory>
{
    public void Configure(EntityTypeBuilder<WeightHistory> builder)
    {
        builder.ToTable("WeightHistory");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Notes)
            .HasMaxLength(1000);

        builder.HasIndex(w => w.UserId);

        builder.HasIndex(w => new { w.UserId, w.Date });
    }
}
