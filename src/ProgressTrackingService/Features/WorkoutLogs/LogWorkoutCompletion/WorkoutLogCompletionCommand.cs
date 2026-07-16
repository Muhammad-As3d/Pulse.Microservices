using BuildingBlocks.Abstractions;
using MediatR;
using ProgressTrackingService.Contracts.WorkoutLogs;

namespace ProgressTrackingService.Features.WorkoutLogs.LogWorkoutCompletion;

public record WorkoutLogCompletionCommand(
    int WorkoutId,
    int SessionId,
    DateTime CompletedAt,
    int DurationInSeconds,
    string Difficulty,
    int CaloriesBurned,
    int Rating,
    string Notes,
    List<ExerciseCompletionDto> ExercisesCompleted
) : IRequest<Result<LogWorkoutCompletionResponse>>;

public sealed record ExerciseCompletionDto(
    Guid ExerciseId,
    int SetsCompleted,
    int RepsCompleted,
    double? WeightUsedKg
);