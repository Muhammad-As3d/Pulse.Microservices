namespace ProgressTrackingService.Entities;

public class Achievement
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string IconUrl { get; set; } = null!;

    public ICollection<UserAchievement> UserAchievements { get; set; } = [];
}
