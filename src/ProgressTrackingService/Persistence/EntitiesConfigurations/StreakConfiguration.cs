using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressTrackingService.Entities;

namespace ProgressTrackingService.Persistence.EntitiesConfigurations;

public class StreakConfiguration : IEntityTypeConfiguration<Streak>
{
    public void Configure(EntityTypeBuilder<Streak> builder)
    {
        builder.ToTable("Streaks");

        builder.HasKey(s => s.UserId);

        builder.Property(s => s.UserId)
            .ValueGeneratedNever();
    }
}
