using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressTrackingService.Entities;

namespace ProgressTrackingService.Persistence.EntitiesConfigurations;

public class UserStatisticsConfiguration : IEntityTypeConfiguration<UserStatistic>
{
    public void Configure(EntityTypeBuilder<UserStatistic> builder)
    {
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.UserId).ValueGeneratedNever();

        builder.Property(u => u.CurrentWeight).HasColumnType("float");
        builder.Property(u => u.StartWeight).HasColumnType("float");
        builder.Property(u => u.TotalWeightLost).HasColumnType("float");
    }
}
