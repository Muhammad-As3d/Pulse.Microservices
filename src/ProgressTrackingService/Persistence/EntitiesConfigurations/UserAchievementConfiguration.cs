using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressTrackingService.Entities;

namespace ProgressTrackingService.Persistence.EntitiesConfigurations;

public class UserAchievementConfiguration : IEntityTypeConfiguration<UserAchievement>
{
    public void Configure(EntityTypeBuilder<UserAchievement> builder)
    {
        builder.ToTable("UserAchievements");

        builder.HasKey(ua => ua.Id);

        builder.HasIndex(ua => ua.UserId);

        builder.HasIndex(ua => new { ua.UserId, ua.AchievementId })
            .IsUnique();

        builder.HasOne(ua => ua.Achievement)
            .WithMany()
            .HasForeignKey(ua => ua.AchievementId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
