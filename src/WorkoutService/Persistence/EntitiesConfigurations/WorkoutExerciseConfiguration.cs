namespace WorkoutService.Persistence.EntitiesConfigurations;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(d => d.Workout)
            .WithMany(p => p.WorkoutExercises)
            .HasForeignKey(d => d.WorkoutId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Exercise)
            .WithMany(p => p.WorkoutExercises)
            .HasForeignKey(d => d.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}