using BuildingBlocks.Abstractions;
using MediatR;
using ProgressTrackingService.Interfaces;
using ProgressTrackingService.Interfaces.Services;

namespace ProgressTrackingService.Features.WorkoutLogs.LogWorkoutCompletion;

//public class WorkoutLogCompletionCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser) : IRequestHandler<WorkoutLogCompletionCommand, Result>
//{
//    public async Task<Result> Handle(WorkoutLogCompletionCommand request, CancellationToken cancellationToken)
//    {
//        var sessions = await unitOfWork
//            .Repository<WorkoutSession>()
//    }
//}
