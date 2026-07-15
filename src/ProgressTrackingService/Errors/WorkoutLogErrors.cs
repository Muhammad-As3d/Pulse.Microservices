using BuildingBlocks.Abstractions;

namespace ProgressTrackingService.Errors;

public static class WorkoutLogErrors
{
    public static readonly Error SessionNotFound = new(
       "RES_SESSION_NOT_FOUND",
       "Workout session not found or does not belong to the caller.",
       StatusCodes.Status404NotFound);

    public static readonly Error SessionNotActive = new(
        "RES_SESSION_NOT_ACTIVE",
        "Workout session is not in an active state.",
        StatusCodes.Status400BadRequest);

    public static readonly Error AlreadyLogged = new(
        "RES_SESSION_ALREADY_LOGGED",
        "This session has already been logged.",
        StatusCodes.Status409Conflict);
}
