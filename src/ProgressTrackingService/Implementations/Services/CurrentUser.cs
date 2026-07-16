using ProgressTrackingService.Interfaces.Services;
using System.Security.Claims;

namespace ProgressTrackingService.Implementations.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
{
    private readonly ClaimsPrincipal User = httpContextAccessor.HttpContext!.User;
    public Guid Id => Guid.TryParse(
        User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId)
        ? userId
        : Guid.Empty;
}
