using FluentValidation;

namespace ProgressTrackingService.Features.WorkoutLogs.LogWorkoutCompletion;

public class WorkoutLogCompletionCommandValidator : AbstractValidator<WorkoutLogCompletionCommand>
{
    public WorkoutLogCompletionCommandValidator()
    {
        RuleFor(x => x.WorkoutId).NotEmpty();
        RuleFor(x => x.SessionId).NotEmpty();
        RuleFor(x => x.CompletedAt).NotEmpty();
        RuleFor(x => x.DurationInSeconds).GreaterThan(0);
        RuleFor(x => x.CaloriesBurned).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Difficulty).NotEmpty();
        RuleFor(x => x.Rating).InclusiveBetween(1, 5)
            .WithMessage("Rating must be between 1 and 5.");
        RuleFor(x => x.ExercisesCompleted).NotEmpty();

        RuleForEach(x => x.ExercisesCompleted).ChildRules(ex =>
        {
            ex.RuleFor(e => e.ExerciseId).NotEmpty();
            ex.RuleFor(e => e.SetsCompleted).GreaterThanOrEqualTo(0);
            ex.RuleFor(e => e.RepsCompleted).GreaterThanOrEqualTo(0);
        });
    }
}
