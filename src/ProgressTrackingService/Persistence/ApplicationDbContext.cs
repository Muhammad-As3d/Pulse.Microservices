using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.Entities;

namespace ProgressTrackingService.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<WorkoutLog> WorkoutLogs { get; set; }
    public DbSet<WorkoutLogExercise> WorkoutLogExercises { get; set; }
    public DbSet<WeightHistory> WeightHistories { get; set; }
    public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<UserAchievement> UserAchievements { get; set; }
    public DbSet<Streak> Streaks { get; set; }
    public DbSet<UserStatistic> UserStatistics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}