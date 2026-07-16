namespace ProgressTrackingService.Contracts.WorkoutLogs;

public record LogWorkoutCompletionResponse(
     Guid ExerciseId,
    int SetsCompleted,
    int RepsCompleted,
    double? WeightUsedKg
);